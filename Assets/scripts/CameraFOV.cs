using System.Collections;
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

            transform.rotation = Quaternion.Euler(31f, cameraAngle + maxRotation * Mathf.Sin(Time.time * speed), 0f);

            RaycastHit hit;
            RaycastHit hit2;
            RaycastHit hit3;
            RaycastHit hit4;
            RaycastHit hit5;

            //Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
            Quaternion spreadAngleNegative = Quaternion.AngleAxis(cameraBorderViewNegative, Vector3.up);
            Quaternion spreadAnglePositive = Quaternion.AngleAxis(cameraBorderViewPositive, Vector3.up);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewLength))
            {
                if (hit.collider.tag == "Player")
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent += detectionRate;
                }

                if (hit.collider.tag != "Player")
                {
                    isSeen = false;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward), out hit2, viewLength))
            {
                if (hit2.collider.tag == "Player")
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent += detectionRate;
                }

                if (hit2.collider.tag != "Player")
                {
                    isSeen = false;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward), out hit3, viewLength))
            {
                if (hit3.collider.tag == "Player")
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent += detectionRate;
                }

                if (hit3.collider.tag != "Player")
                {
                    isSeen = false;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward * 0.5f), out hit4, viewLength))
            {
                if (hit4.collider.tag == "Player")
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent += detectionRate;
                }

                if (hit4.collider.tag != "Player")
                {
                    isSeen = false;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward * 0.5f), out hit5, viewLength))
            {
                if (hit5.collider.tag == "Player")
                {
                    isSeen = true;
                    //EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + EnemyFOV.efov.detectionRate;
                    Gamecontroller.instance.criticalPercent += detectionRate;
                }

                if (hit5.collider.tag != "Player")
                {
                    isSeen = false;
                }
            }
        }

        
        
    }
}