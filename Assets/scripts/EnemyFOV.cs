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
    public float detectionRate = 0.1f;
    public float timer = 3f;
    public float noisetime = 1f;
    public bool timerOn = false;
    public bool noiseTimer = false;
    public bool timesUp = false;
    public static EnemyFOV efov;
    public Gamecontroller Gamecontrolscript;
    
    public void Start()
    {
        efov = this;
        defaultCautionTime = cautionTime;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (!PlayerMovement.pl.pause)
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
                if (timer <= 0)
                {

                    timesUp = true;
                    isDetected = false;
                    timerOn = false;
                    timer = 3f;
                    //onko muuuttunut GIT
                }
            }
            if (noiseTimer)
            {
                noisetime -= Time.deltaTime;
                if (noisetime <=0)
                {
                    timesUp = true;
                    isDetected = false;
                    noiseTimer = false;
                    noisetime = 1;

                }
            }
        }
    }

    void FixedUpdate()
    {
        if (!PlayerMovement.pl.pause)
        {
            RaycastHit hit;
            RaycastHit hit2;
            RaycastHit hit3;
            RaycastHit hit4;
            RaycastHit hit5;
            
            Quaternion spreadAngleNegative = Quaternion.AngleAxis(enemyBorderViewNegative, Vector3.up);
            Quaternion spreadAnglePositive = Quaternion.AngleAxis(enemyBorderViewPositive, Vector3.up);
            Quaternion spreadAngleNegativeHalf = Quaternion.AngleAxis(enemyBorderViewNegative / 2, Vector3.up);
            Quaternion spreadAnglePositiveHalf = Quaternion.AngleAxis(enemyBorderViewPositive / 2, Vector3.up);

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * viewLength, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward) * viewLength, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward) * viewLength, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(spreadAngleNegativeHalf * Vector3.forward) * viewLength, Color.green);
            Debug.DrawRay(transform.position, transform.TransformDirection(spreadAnglePositiveHalf * Vector3.forward) * viewLength, Color.green);

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewLength))
            {
                if (hit.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isDetected = true;
                    
                    timerOn = true;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward), out hit2, viewLength))
            {
                if (hit2.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isDetected = true;
                    timerOn = true;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward), out hit3, viewLength))
            {
                if (hit3.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isDetected = true;
                    timerOn = true;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositiveHalf * Vector3.forward), out hit4, viewLength))
            {
                if (hit4.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isDetected = true;
                    timerOn = true;
                }
            }

            if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositiveHalf * Vector3.forward), out hit5, viewLength))
            {
                if (hit5.collider.tag == "Player" && !PlayerMovement.pl.isCrouching)
                {
                    isDetected = true;
                    timerOn = true;
                }
            }

            if (isDetected == true)
            {
                //Huutomerkki
                /* detectionPercent = detectionPercent + detectionRate; */
                isCautious = true;
                Gamecontroller.instance.criticalPercent += detectionRate;
            }

            if (isDetected == false && isCautious == true && Gamecontroller.instance.criticalPercent > 0)
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
                //isCautious = false;
                isDetected = false;
            }

            /* 1 << LayerMask.NameToLayer("Player") */
        }
    }
        
}
