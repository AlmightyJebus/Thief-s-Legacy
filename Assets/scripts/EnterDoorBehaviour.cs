using System.Collections;
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
    public float currentPosition;

    void Start()
    {
        openPositionLeft = doorLeft.transform.localPosition + new Vector3(openDistance, 0.0f, 0.0f);
        closePositionLeft = doorLeft.transform.localPosition;

        openPositionRight = doorRight.transform.localPosition - new Vector3(openDistance, 0.0f, 0.0f);
        closePositionRight = doorRight.transform.localPosition;
    }

    void Update()
    {
        //currentPosition = (Time.time - 0.1f) / 3;
        distance = Vector3.Distance(transformDoor.position, player.position);

        if (distance < minDistance)
        {
            //doorLeft.transform.position = openPositionLeft;
            //doorRight.transform.position = openPositionRight;
            currentPosition += Time.deltaTime;
            doorLeft.transform.position = Vector3.Lerp(closePositionLeft, openPositionLeft, currentPosition);
            doorRight.transform.position = Vector3.Lerp(closePositionRight, openPositionRight, currentPosition);

            if (doorLeft.transform.position == openPositionLeft && doorRight.transform.position == openPositionRight)
            {
                isOpen = true;
            }
        }

        if (isOpen == true && distance > minDistance && currentPosition >= 0)
        {
            //doorLeft.transform.position = closePositionLeft;
            //doorRight.transform.position = closePositionRight;
            isOpen = false;
            currentPosition = 0f;
            if (isOpen == false && currentPosition == 0)
            {
                //currentPosition ei nouse enää nollasta...
                currentPosition += Time.deltaTime;
                doorLeft.transform.position = Vector3.Lerp(openPositionLeft, closePositionLeft, currentPosition);
                doorRight.transform.position = Vector3.Lerp(openPositionRight, closePositionRight, currentPosition);
            }
        }
    }
    
}
