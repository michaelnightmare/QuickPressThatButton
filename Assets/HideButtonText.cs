using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButtonText : MonoBehaviour
{
    public GameObject buttonText;

    void OnEnable()
    {
        StartCoroutine(RemoveAfterSeconds(.5f, gameObject));
    }

    IEnumerator RemoveAfterSeconds(float seconds, GameObject obj)
    {
        yield return new WaitForSeconds(.5f);
        obj.SetActive(false);
    }


}
