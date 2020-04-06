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
    public CrusherScript crusher;
    public GameObject redFlash;
    public bool redFlashActive;
    

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
            Score.scoreValue += 100;
            crusher.bump();
            correct.Play();
        }
        else
        { 
            wrong.Play();
            redFlash.SetActive(true);
            crusher.negativeBump();
            StartCoroutine(redFlashDeactivate());
   
        }
    
        

    }

    IEnumerator redFlashDeactivate()
    {
        yield return new WaitForSeconds(.2f);
        redFlash.SetActive(false);

    }

    void Update()
    {



    }
    

}
