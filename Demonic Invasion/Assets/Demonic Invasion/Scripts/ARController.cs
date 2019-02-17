using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GoogleARCore;

#if UNITY_EDITOR
using input = GoogleARCore.InstantPreviewInput;
#endif
public class ARController : MonoBehaviour
{
    //list with the planes that AR core detects in the current frame
    private List<DetectedPlane> m_NewTrackedPlanes = new List<DetectedPlane>();

    public GameObject gridPreFab;
    public GameObject portal;
    public bool portalVisible;
    public GameObject arCamera;

	// Use this for initialization
	void Start ()
    {
        portalVisible = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
		//Check AR core session status
        if(Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        // Thia function will fill the list wiht the planes AR core detects in the current frame
        Session.GetTrackables<DetectedPlane>(m_NewTrackedPlanes, TrackableQueryFilter.New);

        for(int i = 0; i < m_NewTrackedPlanes.Count; i++)
        {
            GameObject grid = Instantiate(gridPreFab, Vector3.zero, Quaternion.identity, transform);

            //this function will set the position of grid and will modify the attached verticies.
            grid.GetComponent<GridVisualizer>().Initialize(m_NewTrackedPlanes[i]);
        }

        //check if user touches the sreen
        Touch touch;
        if(Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }

        if (portalVisible != true)
        {
            //Checks to see if the user touched one of the tracked planes
            TrackableHit hit;
            if (Frame.Raycast(touch.position.x, touch.position.y, TrackableHitFlags.PlaneWithinPolygon, out hit))
            {
                //place the portal on the tracked plane that we touch
                //Enable the portal
                portal.SetActive(true);
                portalVisible = true;
                this.GetComponent<AudioSource>().Play();
                //create a new anchor
                Anchor anchor = hit.Trackable.CreateAnchor(hit.Pose);

                //Set position and rotation of the portal
                portal.transform.position = hit.Pose.position;
                portal.transform.rotation = hit.Pose.rotation;

                //Want the portal to face camera when placed
                Vector3 cameraPostion = arCamera.transform.position;

                //the portal should only rotate around the y axis
                cameraPostion.y = hit.Pose.position.y;
                //Rotate the portal to face the camera
                portal.transform.LookAt(cameraPostion, portal.transform.up);

                //AR core keeps updating the anchors according ot the world around it. must attach portal to another anchor.
                portal.transform.parent = anchor.transform;
            }
        }

	}
}
