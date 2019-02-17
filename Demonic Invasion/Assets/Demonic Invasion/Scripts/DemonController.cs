using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonController : MonoBehaviour
{
    public Transform player;
    float moveSpeed = 2;
    float maxDist = 1;
    float minDist = 0.1f;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= minDist)
        {
            //transform.position = new Vector3(player.position.x, transform.position.y, player.transform.position.z);
            float step = moveSpeed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, 0, player.transform.position.z), step);

            //transform.position += transform.forward * moveSpeed * Time.deltaTime;

            //transform.Translate(player.transform.position.x, 0, player.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, transform.position.y, player.position.z), step);





            //if (Vector3.Distance(transform.position, player.position) <= maxDist)
            //{
            //    attack();
            //}

        }
    }

        public void attack()
        {

        }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sword")
        {
            Destroy(this.gameObject);
        }
    }
}
