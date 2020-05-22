using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboScrp : MonoBehaviour
{
 
    public static int comboValue = 1;
    public static int comboIncreaser = 0; 

    Text combo;

    // Start is called before the first frame update
    void Start()
    {
        comboValue = 1;
        comboIncreaser = 0;
        combo = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        combo.text = "Combo X " + comboValue;
    }
}
