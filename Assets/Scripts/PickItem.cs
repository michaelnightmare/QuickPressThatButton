using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public int activeButton;
    public Button buttonLeft;
    public Button buttonLeftUp;
    public Button buttonUp;
    public Button buttonRightUp;
    public Button buttonRight;
    public AudioSource correct;
    public AudioSource wrong;
    public bool RightAnswer;

    void Start()
    {
        Pick();
    }

    void Pick()
    {
        activeButton = Random.Range(0, itemsToPickFrom.Length);
        itemsToPickFrom[activeButton].SetActive(true);
        
    }
    
    public void Check(int current)
    {
        if(activeButton == current)
        {
            RightAnswer = true;
            itemsToPickFrom[activeButton].SetActive(false);
            Pick();
            Score.scoreValue += 100;
            RightAnswer = true;
            correct.Play();
        }
        else 
        {
            Debug.Log("false");
            RightAnswer = false;
        }
    
        

    }

    void Update()
    {
      


    }
    

}
