﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDisable : MonoBehaviour {

    // LAITA OBJEKTIIN JOKA HAKKEROIDAAN!!
    // LAITA AKTIVOITUMAAN KUN HAKKEROINTI ALKAA!!
    // KATSO SAMALLA EnemyFOV.efov.detectionPercent JA isSolved TOIMINTA!!

    public bool canBeDisabled = false;
    public bool isDisabled = false;
    public static CameraDisable disable;
    public GameObject disableText;
    public Transform transformCamera;
    public Transform player;
    public float distance;
    public float minDistance = 2.5f;
    public float disableTime = 10f;
    public float defaultDisableTime = 10f;

    public void Start()
    {
        disable = this;
    }

    public void FixedUpdate()
    {
        distance = Vector3.Distance(transformCamera.position, player.position);

        if (distance < minDistance)
        {
            canBeDisabled = true;
            disableText.SetActive(true);
        }

        if (distance > minDistance)
        {
            canBeDisabled = false;
            disableText.SetActive(false);
        }

        if (isDisabled)
        {
            disableTime = disableTime - Time.deltaTime;
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
