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

 
    void Start()
    {
        startPosition = Crusher.transform.position;

    }
    public void bump()
    {
        transform.Translate(Vector3.up* bumpAmount);
    }

    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
       //t += Time.deltaTime / timeToReachTarget;
       //transform.position = Vector2.Lerp(startPosition, target.transform.position, t);

    }


    
}
