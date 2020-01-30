using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherScript : MonoBehaviour {

    public GameObject Crusher;
    public GameObject ButtonPressed;

    float t;
    float pauseTime;
    Vector2 startPosition;
    public GameObject target;
    public float timeToReachTarget;

    // Use this for initialization
    void Start ()
    {
        startPosition = Crusher.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
       

        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector2.Lerp(startPosition, target.transform.position, t);
    }

    
}
