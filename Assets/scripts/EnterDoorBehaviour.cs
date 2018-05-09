﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDoorBehaviour : MonoBehaviour
{
    public bool isOpen = false;
    public GameObject doorLeft;
    public GameObject doorRight;
    public float openDistance = -1f;

    public Vector3 openPositionLeft;
    public Vector3 closePositionLeft;
    public Vector3 openPositionRight;
    public Vector3 closePositionRight;

    public Transform transformDoor;
    public Transform player;
    
    public float distance;
    public float minDistance = 2f;
    float currentPosition;

    void Start()
    {
        openPositionLeft = doorLeft.transform.localPosition + new Vector3(openDistance, 0.0f, 0.0f);
        closePositionLeft = doorLeft.transform.localPosition;

        openPositionRight = doorRight.transform.localPosition - new Vector3(openDistance, 0.0f, 0.0f);
        closePositionRight = doorRight.transform.localPosition;
    }

    void Update()
    {
        currentPosition = (Time.time - 0.1f) / 5;
        distance = Vector3.Distance(transformDoor.position, player.position);

        if (distance < minDistance)
        {
            isOpen = true;
            //doorLeft.transform.position = openPositionLeft;
            //doorRight.transform.position = openPositionRight;
            doorLeft.transform.position = Vector3.Slerp(closePositionLeft, openPositionLeft, currentPosition);
            doorRight.transform.position = Vector3.Slerp(closePositionRight, openPositionRight, currentPosition);
            //toimii kerran
        }

        if (distance > minDistance)
        {
            isOpen = false;
            doorLeft.transform.position = closePositionLeft;
            doorRight.transform.position = closePositionRight;
            //doorLeft.transform.position = Vector3.Slerp(openPositionLeft, closePositionLeft, currentPosition);
            //doorRight.transform.position = Vector3.Slerp(openPositionRight, closePositionRight, currentPosition);
        }
    }
    
}
