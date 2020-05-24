using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CrusherRoom debugStartRoom;
    public CrusherRoom currentRoom;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }        
        else if(instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        currentRoom = debugStartRoom;
        currentRoom.SetRoomActive(true);
    }

    public void ControlPanelButtonPressed(int bIndex)
    {
        if (currentRoom == null) return;

        if (currentRoom.TryButtonPress(bIndex))
        {
            CorrectButtonPressed();
        }
        else
        {
            IncorrectButtonPressed();
        }
    }

    void CorrectButtonPressed()
    {

    }

    void IncorrectButtonPressed()
    {

    }
}
