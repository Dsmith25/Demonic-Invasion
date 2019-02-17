using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Rendering;

public class PortalManager : MonoBehaviour
{
    public GameObject mainCamera;

    public GameObject sponza;
    private Material[] sponzaMaterials;

    //public bool playerEntered;

	// Use this for initialization
	void Start ()
    {
        sponzaMaterials = sponza.GetComponent<Renderer>().sharedMaterials;
        //playerEntered = false;
	}
	
	
	void OnTriggerStay (Collider collider)
    {
        Vector3 camPositionInPortalSpace = transform.InverseTransformPoint(mainCamera.transform.position);

        if (camPositionInPortalSpace.y < .5f)
        {
            //playerEntered = true;
            // Disable Stencil when close to portal
            for (int i = 0; i < sponzaMaterials.Length; i++)
            {
                sponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Always);
            }
        }
        else
        {
            //playerEntered = false;
            // Enables stencil if far enough away from portal
            for (int i = 0; i < sponzaMaterials.Length; i++)
            {
                sponzaMaterials[i].SetInt("_StencilComp", (int)CompareFunction.Equal);
            }
        }
	}

    
}
