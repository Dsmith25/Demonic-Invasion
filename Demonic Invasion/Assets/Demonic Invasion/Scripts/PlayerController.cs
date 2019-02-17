using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool playerEntered;
    public static PlayerController instance;
    public bool crystalDestroyred;

	// Use this for initialization
	void Start ()
    {
        instance = this;
        playerEntered  = false;
        crystalDestroyred = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Entry")
        {
            if(playerEntered == false)
            {
                playerEntered = true;
            }
            else if(playerEntered == true)
            {
                playerEntered = false;
            }
        }
    }
}
