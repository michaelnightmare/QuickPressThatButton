using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class Crusher : MonoBehaviour
{
    [Header("Options")]
    public float crusherSpeed = 1f;
    public float crusherBumpUpDist = .1f;
    public float crusherBumpDownDist = .1f;

    Vector3 startPosition;
    Vector3 targetPosition;
    bool active = false;
    Collider col;
    Vector3 crusherBottom
    {
        get
        {
            if (!col) col = GetComponent<Collider>();
            return new Vector3(0f, col.bounds.min.y, 0f);
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        startPosition = transform.position;
        targetPosition = startPosition + (Vector3.zero - crusherBottom);
    }

    public void BumpUpCrusher()
    {
        transform.Translate(Vector3.up * crusherBumpUpDist);
    }

    public void BumpDownCrusher()
    {
        transform.Translate(Vector3.down * crusherBumpDownDist);
    }

    public void SetCrusherNormalizedPosition(float n)
    {
        transform.position = Vector3.Lerp(startPosition, targetPosition, n);
    }

    [Button]
    public void ResetCrusher()
    {
        transform.position = startPosition;
        SetCrusherActive(false);
    }

    [Button]
    public void ToggleCrusherActive()
    {
        active = !active;
    }

    public void SetCrusherActive(bool a)
    {
        active = a;
    }

    // Update is called once per frame
    void Update()
    {
        if(active && crusherBottom.y > 0f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * crusherSpeed);
        }
    }
}
