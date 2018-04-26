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
    public float detectionPercent;
    public float detectionRate;
    public float timer = 3f;
    public bool timerOn = false;
    public bool timesUp = false;
    
    public static EnemyFOV efov;
    
    public void Start()
    {
        efov = this;

        defaultCautionTime = cautionTime;
        
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        //näitä arvoja muutetaan, kun pelaaja löytää aarteen, FOV kasvaa?
        if (PlayerMovement.pl.isStolen)
        {
            enemyBorderViewNegative = -23f;
            enemyBorderViewPositive = 23f;
            viewLength = 3;
        }

        if (timerOn)
        {
            timer -= Time.deltaTime;
            if (timer <=0)
            {

                timesUp = true;
                isDetected = false;
                timerOn = false;
                timer = 3f;
            }
        }
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        RaycastHit hit2;
        RaycastHit hit3;

        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
        Quaternion spreadAngleNegative = Quaternion.AngleAxis(enemyBorderViewNegative, Vector3.up);
        Quaternion spreadAnglePositive = Quaternion.AngleAxis(enemyBorderViewPositive, Vector3.up);
        
        /*
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewLength, 1 << LayerMask.NameToLayer("Player")) && hit.collider.tag == "Player")

        {
            isDetected = true;
            timerOn = true;
        }
        */
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewLength))

        {
            if (hit.collider.tag == "Player")
            {
                isDetected = true;
                timerOn = true;
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward), out hit2, viewLength))
        {
            if (hit2.collider.tag == "Player")
            {
                isDetected = true;
                timerOn = true;
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward), out hit3, viewLength))
        {
            if (hit3.collider.tag == "Player")
            {
                isDetected = true;
                timerOn = true;
            }
        }
        
        if (isDetected == true)
        {
            //Huutomerkki
            detectionPercent = detectionPercent + detectionRate;
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

        /* 1 << LayerMask.NameToLayer("Player") */
    }
}
