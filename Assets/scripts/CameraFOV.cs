﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFOV : MonoBehaviour
{
    public bool isSeen = false;
    public float cameraBorderViewNegative;
    public float cameraBorderViewPositive;
    public float viewLength;
    public float defaultViewLength;
    public float cameraAngle;
    public float cameraVerticalAngle;
    public float detectionRate = 0.1f;

    public float speed = 1f;
    public float maxRotation;
    public PlayerMovement playerScript;
    
    public static CameraFOV cfov;
    public Gamecontroller gamecontrolscript;
    

    void Start()
    {
        cfov = this;
    }

    void FixedUpdate()
    {
        //If pause is off
        if (!PlayerMovement.pl.pause)
        {
            //transform.Rotate(0, 30 * Time.deltaTime, 0);

            
                transform.rotation = Quaternion.Euler(cameraVerticalAngle, cameraAngle + maxRotation * Mathf.Sin(Time.time * speed), 0f);
            

            RaycastHit hit;
            RaycastHit hit2;
            RaycastHit hit3;
            RaycastHit hit4;
            RaycastHit hit5;

            //Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
            Quaternion spreadAngleNegative = Quaternion.AngleAxis(cameraBorderViewNegative, Vector3.up);
            Quaternion spreadAnglePositive = Quaternion.AngleAxis(cameraBorderViewPositive, Vector3.up);
            Quaternion spreadAngleNegativeHalf = Quaternion.AngleAxis(cameraBorderViewNegative / 2, Vector3.up);
            Quaternion spreadAnglePositiveHalf = Quaternion.AngleAxis(cameraBorderViewPositive / 2, Vector3.up);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * viewLength, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward) * viewLength, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward) * viewLength, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(spreadAngleNegativeHalf * Vector3.forward) * viewLength, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(spreadAnglePositiveHalf * Vector3.forward) * viewLength, Color.green);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewLength))
            {
                if (hit.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent = Gamecontroller.instance.criticalPercent + detectionRate;
                }

                if (hit.collider.tag != "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = false;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward), out hit2, viewLength))
            {
                if (hit2.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent = Gamecontroller.instance.criticalPercent + detectionRate;
                }

                if (hit2.collider.tag != "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = false;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward), out hit3, viewLength))
            {
                if (hit3.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent = Gamecontroller.instance.criticalPercent + detectionRate;
                }

                if (hit3.collider.tag != "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = false;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositiveHalf * Vector3.forward), out hit4, viewLength))
            {
                if (hit4.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent = Gamecontroller.instance.criticalPercent + detectionRate;
                }

                if (hit4.collider.tag != "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = false;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositiveHalf * Vector3.forward), out hit5, viewLength))
            {
                if (hit5.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent = Gamecontroller.instance.criticalPercent + detectionRate;
                }

                if (hit5.collider.tag != "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isSeen = false;
                }
            }
        }
    }
}