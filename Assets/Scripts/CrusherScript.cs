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
    public float speed;
    public float bumpAmount;
    public float negativeBumpAmount;
    public Vector2 maxPosition;
    public Vector2 minPosition;

 
    void Start()
    {
        startPosition = Crusher.transform.position;

    }
    public void bump()
    {
        if (Crusher.transform.position.y > startPosition.y)
        {
            Debug.Log("Top hit");
        }
        else
        {
            transform.Translate(Vector3.up * bumpAmount);
        }
    }

    public void negativeBump()
    {
        transform.Translate(Vector3.down * negativeBumpAmount);
    }


    void Update()
    {
        if (Crusher.transform.position.y >= minPosition.y)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }
        else
        {
            Debug.Log("Bottom hit");
        }
    }


    
}
