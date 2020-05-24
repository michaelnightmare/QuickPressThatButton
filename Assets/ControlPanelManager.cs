using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelManager : MonoBehaviour
{
    GameManager gm;

    [Header("References")]
    public Button b0;
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;

        //initialize buttons
        b0.onClick.AddListener(delegate { ButtonPressed(0); });
        b1.onClick.AddListener(delegate { ButtonPressed(1); });
        b2.onClick.AddListener(delegate { ButtonPressed(2); });
        b3.onClick.AddListener(delegate { ButtonPressed(3); });
        b4.onClick.AddListener(delegate { ButtonPressed(4); });
    }

    public void ButtonPressed(int index)
    {
        Debug.Log("Button Pressed: " + index);
        gm.ControlPanelButtonPressed(index);
    }
}
