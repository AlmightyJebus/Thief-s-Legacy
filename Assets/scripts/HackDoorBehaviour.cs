using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackDoorBehaviour : MonoBehaviour
{
    public bool isOpen = false;
    public GameObject doorLeft;
    public GameObject doorRight;
    public float openDistance = -2f;

    public Vector3 openPositionLeft;
    public Vector3 closePositionLeft;
    public Vector3 openPositionRight;
    public Vector3 closePositionRight;

    public static HackDoorBehaviour hackDoorBeh;

    void Start()
    {
        hackDoorBeh = this;

        openPositionLeft = doorLeft.transform.localPosition + new Vector3(0.0f, 0.0f, openDistance);
        closePositionLeft = doorLeft.transform.localPosition;

        openPositionRight = doorRight.transform.localPosition - new Vector3(0.0f, 0.0f, openDistance);
        closePositionRight = doorRight.transform.localPosition;
    }

    void Update()
    { 
        //Viittaus minipeliin tähän
        if (HackingMiniGameDoor.hackingDoor.isSolved)
        {
            isOpen = true;
        }

        if (isOpen == true)
        {
            doorLeft.transform.position = openPositionLeft;
            doorRight.transform.position = openPositionRight;
        }
    }
}