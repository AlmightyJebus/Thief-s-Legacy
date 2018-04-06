using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyFOV : MonoBehaviour
{
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
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        RaycastHit hit2;
        RaycastHit hit3;

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
                //ReloadScene();
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
                //ReloadScene();
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
                //ReloadScene();
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
    }

    public static void ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(currentScene);
    }
    
    /*
    //vanha script, toimii truehen asti
    void Update()
    {
        RaycastHit hit;
        
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            if(hit.collider.tag == "Player")
            {
                isSeen = true;
                //Gamecontroller.instance.Seen();
            }

            else
            {
                isSeen = false;
            }
        }
    }
    */
}
