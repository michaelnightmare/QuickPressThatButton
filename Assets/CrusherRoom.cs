using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherRoom : MonoBehaviour
{

    [Header("References")]
    public Sprite[] buttonSprites = new Sprite[5];
    public AudioClip wrongButtonClip;
    public AudioClip rightButtonClip;
    public AudioSource roomSource;
    public GameObject wrongButtonLight;

    Robot roomRobot;
    Crusher roomCrusher;
    public SpriteRenderer buttonCue;
    int desiredButton = 0;

    bool active;

    private void Awake()
    {
        roomRobot = GetComponentInChildren<Robot>();
        roomCrusher = GetComponentInChildren<Crusher>();
    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizeDesiredButton();
    }

    public void SetRoomActive(bool a)
    {
        active = a;
        if (a) OnActiveRoom();
        if(!a) OnDeactivateRoom();
    }

    void OnActiveRoom()
    {
        wrongButtonLight.SetActive(false);
        roomCrusher.ResetCrusher();
        roomCrusher.SetCrusherActive(true);
        roomRobot.currentLives = roomRobot.totalNumLives;
    }

    void OnDeactivateRoom()
    {
        wrongButtonLight.SetActive(true);
        roomCrusher.ResetCrusher();
        roomCrusher.SetCrusherActive(false);
    }

    void RandomizeDesiredButton()
    {
        desiredButton = Random.Range(0, 4);
        buttonCue.sprite = buttonSprites[desiredButton];
    }

    public bool TryButtonPress(int index)
    {
        Debug.Log("Pressed Button: " + index + "\n" + "Desired Button: " + desiredButton);

        if(index == desiredButton)
        {
            CorrectButtonPressed();
            RandomizeDesiredButton();
            return true;
        }
        else
        {
            IncorrectButtonPressed();
            RandomizeDesiredButton();
            return false;
        }
    }

    void CorrectButtonPressed()
    {
        roomCrusher.BumpUpCrusher();
        roomSource.PlayOneShot(rightButtonClip);
    }

    void IncorrectButtonPressed()
    {
        roomCrusher.BumpDownCrusher();
        FlashWrongButtonLight();
        roomSource.PlayOneShot(wrongButtonClip);
    }

    public void FlashWrongButtonLight()
    {
        StopAllCoroutines();
        StartCoroutine(FlashingWrongButtonLight());
    }

    IEnumerator FlashingWrongButtonLight()
    {
        wrongButtonLight.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wrongButtonLight.SetActive(false);
    }

    public void CrusherHitRobot()
    {
        int curHealth = roomRobot.currentLives;
        int newHealth = curHealth - 1;
        if(newHealth <= 0)
        {
            //robot dead
            SetRoomActive(false);
            roomRobot.currentLives = 0;
            roomCrusher.SetCrusherNormalizedPosition(1);
        }
        else
        {
            roomRobot.currentLives = newHealth;
            roomCrusher.ResetCrusher();
            roomCrusher.SetCrusherActive(true);
            FlashWrongButtonLight();
            roomSource.PlayOneShot(wrongButtonClip);
        }
    }

}
