using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Patroller : MonoBehaviour
{

    public static Patroller patr;
    public PlayerMovement playerscript;

    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    public Transform pos8;
    public Transform pos;


    public bool position1 = true;
    public bool position2 = false;
    public bool position3 = false;
    public bool position4 = false;
    public bool position5 = false;
    public bool position6 = false;
    public bool position7 = false;
    public bool position8;




    public GameObject questionText;
    public GameObject warningText;
    public GameObject alertText;

    public NavMeshAgent agent;
    EnemyFOV enemyScript;

    public Transform target;
    public Transform myTransform;
    public float followSpeed = 3f;
    public bool start = true;
    public bool disable = false;
    public bool unpause = false;



    void Start()
    {

        patr = this;

        agent = gameObject.GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        if (agent == null)
        {
            Debug.LogError("hei muista laittaa agentti tähän", this);
        }


        /*   theEnemy = GameObject.FindGameObjectWithTag("Enemy");
           if (theEnemy == null)
           {
               Debug.LogError("ei löydy enemy", this);

           }
           */
        enemyScript = gameObject.GetComponent<EnemyFOV>();

        if (enemyScript == null)
        {
            Debug.LogError("ei löydy enemyscript", enemyScript);
        }



    }


    void Update()
    {



        if (unpause)
        {
            Continue();
            unpause = false;
            Move();

        }
        if (PlayerMovement.pl.pause)
        {
            Stop();
        }



        if (!PlayerMovement.pl.pause)
        {
            //enemy chase
            if (enemyScript.isDetected == true)
            {
                transform.LookAt(target);
                transform.Translate(Vector3.forward * followSpeed * Time.deltaTime);
                warningText.SetActive(true);
                disable = true;
            }

            //enemy searching
            if (enemyScript.isCautious == true && enemyScript.isDetected == false)
            {
                transform.Rotate(0, 50 * Time.deltaTime, 0);
                GetComponent<NavMeshAgent>().speed = 0f;
                questionText.SetActive(true);
                warningText.SetActive(false);
                start = false;
                disable = true;
            }
            //enemy continue patrol
            if (enemyScript.isCautious == false && start == false)
            {

                Continue();
                
            }

            
            

            /*if (start)
            {
                //questionText.SetActive(false);
                agent.SetDestination(pos1.position);
                GetComponent<NavMeshAgent>().speed = 3f;
            }

            if (PlayerMovement.pl.isStolen)
            {
                GetComponent<NavMeshAgent>().speed = 8f;
                agent = GetComponent<NavMeshAgent>();
                alertText.SetActive(true);
            }


            /*if (enemyScript.isDetected == true && start == false)
            {

                warningText.SetActive(true);
                disable = true;
            }
            if (enemyScript.isDetected == false && start == true)
            {
                warningText.SetActive(false);
            } */
        }

    }

    public void Continue()
    {
        questionText.SetActive(false);
        agent.SetDestination(pos1.position);
        GetComponent<NavMeshAgent>().speed = 3f;
        start = true;
        disable = false;
    }

    public void Stop()
    {
        GetComponent<NavMeshAgent>().speed = 0f;
    }
    public void Move()
    {
        GetComponent<NavMeshAgent>().speed = 3f;
    }


    public void OnTriggerEnter(Collider other)
    {


        if (PlayerMovement.pl.pause==false)
        {
            //enemy patrol route 1

            if (disable == false)
            {
                if (other.tag == "1")
                {
                    agent.SetDestination(pos2.position);
                    start = true;
                }

                if (other.tag == "2")
                {
                    agent.SetDestination(pos3.position);

                }

                if (other.tag == "3")
                {
                    agent.SetDestination(pos4.position);
                }

                if (other.tag == "4")
                {
                    agent.SetDestination(pos5.position);
                }

                if (other.tag == "5")
                {
                    agent.SetDestination(pos6.position);
                }

                if (other.tag == "6")
                {
                    agent.SetDestination(pos7.position);
                }

                if (other.tag == "7")
                {
                    agent.SetDestination(pos8.position);
                }
                if (other.tag == "8")
                {
                    agent.SetDestination(pos1.position);
                }
            }
        }





    }
}

        


    







