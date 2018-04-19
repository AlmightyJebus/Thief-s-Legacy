using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFOV : MonoBehaviour
{
    public bool isSeen = false;
    public float cameraBorderViewNegative = -23f;
    public float cameraBorderViewPositive = 23f;
    public float viewLength = 3;
    public float cameraAngle;

    public float speed = 1f;
    public float maxRotation;
    public PlayerMovement playerScript;
    
    public static CameraFOV cfov;

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

            //Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
            Quaternion spreadAngleNegative = Quaternion.AngleAxis(cameraBorderViewNegative, Vector3.up);
            Quaternion spreadAnglePositive = Quaternion.AngleAxis(cameraBorderViewPositive, Vector3.up);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewLength))
            {
                if (hit.collider.tag == "Player")
                {
                    isSeen = true;
                    EnemyFOV.efov.detectionPercent += 0.5f;
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
                    EnemyFOV.efov.detectionPercent += 0.5f;
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
                    EnemyFOV.efov.detectionPercent += 0.5f;
                }

                if (hit3.collider.tag != "Player")
                {
                    isSeen = false;
                }
            }
        }

        
        
    }
}