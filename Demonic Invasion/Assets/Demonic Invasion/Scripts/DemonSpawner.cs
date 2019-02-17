using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpawner : MonoBehaviour
{
    public GameObject[] demon;
    public float spawnMin;
    public float spawnMax;
    
    public GameObject portalManager;

    void Start()
    {
        Spawn();
    }

     //void Update()
     //{
     //   if (PlayerController.instance.playerEntered == true)
     //   {
     //       StartCoroutine(timer());
     //   }
     //}

    // spawns bombs at a random range at random intervals
    void Spawn()
    {
        if(PlayerController.instance.playerEntered == true)
        {
            float rand = Random.Range(0, 1000);
            //if random number is greater than 700 make a platform
            if (rand > 500)
            {
                Instantiate(demon[Random.Range(0, demon.GetLength(0))], transform.position, Quaternion.identity);
            }
            //invoke spawn at random time interval between min and max
            Invoke("Spawn", Random.Range(spawnMin, spawnMax));
        }
        
    }

    IEnumerator timer()
    {
        yield return new WaitForSecondsRealtime(10);
        Instantiate(demon[Random.Range(0, demon.GetLength(0))], transform.position, Quaternion.identity);

    }
}
