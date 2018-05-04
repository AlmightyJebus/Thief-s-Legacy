using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraDisable : MonoBehaviour
{
    public bool canBeDisabled = false;
    public bool isDisabled = false;
    public static CameraDisable disable;
    public GameObject disableText;
    public Transform transformCamera;
    public Transform player;
    public float distanceFromCamera;
    public float minDistanceFromCamera = 2.5f;
    public float disableTime = 10f;
    public float defaultDisableTime = 10f;

    public void Start()
    {
        disable = this;
    }

    public void FixedUpdate()
    {
        distanceFromCamera = Vector3.Distance(transformCamera.position, player.position);

        if (distanceFromCamera <= minDistanceFromCamera)
        {
            disableText.SetActive(true);
            canBeDisabled = true;
        }

        if (distanceFromCamera > minDistanceFromCamera)
        {
            disableText.SetActive(false);
            canBeDisabled = false;
        }

        if (isDisabled)
        {
            disableTime = disableTime - Time.deltaTime;
            disableText.SetActive(false);
        }

        if (disableTime <= 0)
        {
            isDisabled = false;
            disableTime = defaultDisableTime;
            canBeDisabled = true;
            GetComponent<CameraFOV>().enabled = true;
        }

        if (canBeDisabled == true && Input.GetKey(KeyCode.E))
        {
            if (disableTime >= 0)
            {
                isDisabled = true;
                canBeDisabled = false;
                GetComponent<CameraFOV>().enabled = false;
            }
        }
    }
}
