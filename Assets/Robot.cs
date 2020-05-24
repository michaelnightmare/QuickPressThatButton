using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    CrusherRoom room;
    public Slider healthSlider;
    public int totalNumLives = 3;
    private int _currentLives = 0;
    public int currentLives
    {
        get { return _currentLives; }
        set
        {
            _currentLives = Mathf.Clamp(value, 0, totalNumLives);
            UpdateHealthSlider();
        }
    }

    private void Start()
    {
        room = GetComponentInParent<CrusherRoom>();
        ResetRobot();
    }

    public void ResetRobot()
    {
        currentLives = totalNumLives;
    }

    void UpdateHealthSlider()
    {
        healthSlider.value = (float) currentLives / totalNumLives;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Crusher")
        {
            room.CrusherHitRobot();
        }
    }
}
