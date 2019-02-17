using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MCP : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        endGame();
	}
    
    void endGame()
    {
        if (PlayerController.instance.crystalDestroyred == true && PlayerController.instance.playerEntered == false)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
