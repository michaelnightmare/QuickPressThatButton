using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickItem : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public GameObject YEA;
    public int activeButton;
    public Button buttonLeft;
    public Button buttonLeftUp;
    public Button buttonUp;
    public Button buttonRightUp;
    public Button buttonRight;


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
            itemsToPickFrom[activeButton].SetActive(false);
            Pick();
        }
        else
        {

        }

    }

    void Update()
    {
        if(buttonLeft)
        {
            Check(0);
        }
        else if (buttonLeftUp)
        {
            Check(1);
        }
        else if (buttonUp)
        {
            Check(2);
        }
        else if (buttonRightUp)
        {
            Check(3);
        }
        else if (buttonRight)
        {
            Check(4);
        }
    }


}
