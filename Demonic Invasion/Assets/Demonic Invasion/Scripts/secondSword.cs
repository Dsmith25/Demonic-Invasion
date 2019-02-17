using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondSword : MonoBehaviour
{
    public GameObject swordStart;
    public GameObject swordEnd;
    public GameObject sword;

    public float speed = 1.0f;
    private float startTime;
    //private float journeyLength;
    
    public float timeToLerp;
    private bool isLerping;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Quaternion startRotation;
    private Quaternion endRotation;
   // bool isSwiping;
    private float _timeStartedLerping;

    private Vector2 fingerDown;
    private Vector2 fingerUp;
    public bool detectSwipeOnlyAfterRelease = false;

    public float SWIPE_THRESHOLD = 20f;

    void startLerping()
    {
        sword.SetActive(true);
        isLerping = true;
        _timeStartedLerping = Time.time;
        startPosition = swordStart.transform.position;
        endPosition = swordEnd.transform.position;

        startRotation = swordStart.transform.rotation;
        endRotation = swordEnd.transform.rotation;
    }
    // Use this for initialization
    void Start ()
    {
        //isSwiping = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUp = touch.position;
                fingerDown = touch.position;
            }

            //Detects Swipe while finger is still moving
            if (touch.phase == TouchPhase.Moved)
            {
                if (!detectSwipeOnlyAfterRelease)
                {
                    fingerDown = touch.position;
                    checkSwipe();
                }
            }

            //Detects swipe after finger is released
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDown = touch.position;
                checkSwipe();
            }
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    startLerping();
        //    sword.GetComponent<AudioSource>().Play();
        //}
    }
    private void FixedUpdate()
    {
        if(isLerping)
        {
            float timeSinceStarted = Time.time - _timeStartedLerping;
            float percentageComplete = timeSinceStarted / timeToLerp;

            
            sword.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
            sword.transform.rotation = Quaternion.Lerp(startRotation, endRotation, percentageComplete);

            if(percentageComplete >=1.0f)
            {
                isLerping = false;
                sword.SetActive(false);
                //isSwiping = false;
            }
        }
    }

    void checkSwipe()
    {
        //Check if Vertical swipe
        if (verticalMove() > SWIPE_THRESHOLD && verticalMove() > horizontalValMove())
        {
            //Debug.Log("Vertical");
            if (fingerDown.y - fingerUp.y > 0)//up swipe
            {
                OnSwipeUp();
            }
            else if (fingerDown.y - fingerUp.y < 0)//Down swipe
            {
                OnSwipeDown();
            }
            fingerUp = fingerDown;
        }

        //Check if Horizontal swipe
        else if (horizontalValMove() > SWIPE_THRESHOLD && horizontalValMove() > verticalMove())
        {
            //Debug.Log("Horizontal");
            if (fingerDown.x - fingerUp.x > 0)//Right swipe
            {
                OnSwipeRight();
            }
            else if (fingerDown.x - fingerUp.x < 0)//Left swipe
            {
                OnSwipeLeft();
            }
            fingerUp = fingerDown;
        }

        //No Movement at-all
        else
        {
            //Debug.Log("No Swipe!");
        }
    }

    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    void OnSwipeUp()
    {
        startLerping();
        sword.GetComponent<AudioSource>().Play();
    }

    void OnSwipeDown()
    {
        startLerping();
        sword.GetComponent<AudioSource>().Play();
    }

    void OnSwipeLeft()
    {
        startLerping();
        sword.GetComponent<AudioSource>().Play();
    }

    void OnSwipeRight()
    {
        startLerping();
        sword.GetComponent<AudioSource>().Play();
    }
}
