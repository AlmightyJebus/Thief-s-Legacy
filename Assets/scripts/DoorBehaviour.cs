using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    public bool isOpen = false;
    public GameObject doorLeft;
    public GameObject doorRight;
    public float openDistance = -3.0f;

    private Vector3 openPosition;
    private Vector3 closePosition;

    void Start()
    {
        openPosition = doorLeft.transform.localPosition + new Vector3(0.0f, 0.0f, openDistance);
        closePosition = doorLeft.transform.localPosition;

        openPosition = doorRight.transform.localPosition - new Vector3(0.0f, 0.0f, openDistance);
        closePosition = doorRight.transform.localPosition;
    }

    void Update()
    {
        if (isOpen == true)
        {
            
        }
    }
}