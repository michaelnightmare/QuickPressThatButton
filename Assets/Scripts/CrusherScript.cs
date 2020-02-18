using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherScript : MonoBehaviour
{

    public GameObject Crusher;
    public GameObject ButtonPressed;

    float t;
    float pauseTime;
    Vector2 startPosition;
    public GameObject target;
    public float timeToReachTarget;
    public PickItem correct;
    public bool delayOn;

 
    void Start()
    {
        startPosition = Crusher.transform.position;
        delayOn = false; 
    }

    void delay()
    {
        if (correct.RightAnswer == true && delayOn == false)
        {
            timeToReachTarget += .1f;
        }
        else
        {
          
        }
      
    }
  
 

    void Update()
    {
        delay();
       t += Time.deltaTime / timeToReachTarget;
       transform.position = Vector2.Lerp(startPosition, target.transform.position, t);
        delayOn = false;
    }


    
}
