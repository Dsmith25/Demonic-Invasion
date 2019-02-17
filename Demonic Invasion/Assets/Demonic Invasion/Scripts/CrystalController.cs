using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sword" || collision.gameObject.tag == "Player" )
        {
            PlayerController.instance.crystalDestroyred = true;
            this.GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
        }
    }
}
