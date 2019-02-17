using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject swordPoint;
    
    public Camera camera;
    Rigidbody rb;
    Vector3 startPosition;
    //Vector3 playerDirection;
    Quaternion startRotation;
    //public float spawnDis;
	// Use this for initialization
	void Start ()
    {
        rb = swordPoint.GetComponent<Rigidbody>();
        //playerDirection = camera.transform.forward;
        startPosition = swordPoint.transform.position;
        startRotation = swordPoint.transform.rotation;      
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Vector3 spawnPos = startPosition + playerDirection * spawnDis;

        if (Input.GetMouseButtonDown(0))
        {
            swordPoint.SetActive(true);
            //sword = Instantiate(Resources.Load<GameObject>("Prefabs/sword"), spawnPos, startRotation);
            
        }
        if (Input.GetMouseButton(0))
        {
            //get mouse possition
            float mousex = (Input.mousePosition.x);
            float mousey = (Input.mousePosition.y);
            //adapt it to screen
            // 5 in z to be in the front of the camera, but up to you, just avoid 0
            Vector3 mouseposition = camera.ScreenToWorldPoint(new Vector3(mousex, mousey, 1f));
            // add movement tot he sword
            rb.AddTorque(mousex, 0, 1);
            //make your gameobject follow your input
            swordPoint.transform.position = mouseposition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            //Destroy(sword.gameObject);
            swordPoint.transform.position = startPosition;
            swordPoint.transform.rotation = startRotation;
            //sword.transform.rotation = Quaternion.Euler(camera.transform.rotation.x, camera.transform.rotation.y, camera.transform.rotation.z);
            swordPoint.SetActive(false);
        }

    }
}
