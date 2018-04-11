using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFOV : MonoBehaviour
{

    public Transform target;
    public Transform myTransform;

    public bool isDetected = false;
    public bool isCautious = false;
    public float enemyBorderViewNegative = -23f;
    public float enemyBorderViewPositive = 23f;
    public float viewLength = 3;
    public float cautionTime = 10.0f;
    public float defaultCautionTime;
    public float detectionPercent = 0.0f;
    

    public void Start()
    {
        defaultCautionTime = cautionTime;
        

        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void FixedUpdate()
    {
        RaycastHit hit;
        RaycastHit hit2;
        RaycastHit hit3;
        RaycastHit spherehit;

        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
        Quaternion spreadAngleNegative = Quaternion.AngleAxis(enemyBorderViewNegative, Vector3.up);
        Quaternion spreadAnglePositive = Quaternion.AngleAxis(enemyBorderViewPositive, Vector3.up);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewLength))
        {
            if (hit.collider.tag == "Player")
            {
                isDetected = true;
            }

            if (hit.collider.tag != "Player")
            {
                isDetected = false;
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward), out hit2, viewLength))
        {
            if (hit2.collider.tag == "Player")
            {
                isDetected = true;
            }

            if (hit2.collider.tag != "Player")
            {
                isDetected = false;
            }
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward), out hit3, viewLength))
        {
            if (hit3.collider.tag == "Player")
            {
                isDetected = true;
            }

            if (hit3.collider.tag != "Player")
            {
                isDetected = false;
            }
        }
       
        
        if (isDetected == true)
        {
            //Huutomerkki
            detectionPercent += 0.5f;
            isCautious = true;
        }

        if (isDetected == false && isCautious == true && detectionPercent > 0)
        {
            isCautious = true;
            cautionTime -= Time.deltaTime;
        }
        
        if (isCautious == true && cautionTime < 0)
        {
            isCautious = false;
            cautionTime = defaultCautionTime;
        }

       if (PlayerMovement.pl.isCrouching)
        {
            isCautious = false;
            isDetected = false;
        }
    }
}
