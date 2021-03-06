﻿using System.Collections;
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
    //public Transform pos;


    public bool position1 = true;
    public bool position2 = false;
    public bool position3 = false;
    public bool position4 = false;
    public bool position5 = false;
    public bool position6 = false;
    public bool position7 = false;
    public bool position8 = false;




    public GameObject questionText;
    public GameObject warningText;
    public GameObject alertText;

    public NavMeshAgent agent;
    EnemyFOV enemyScript;
    public float guardSpeed = 3f;
    public float enemyMinDistance=1.25f;
    public float enemyMaxDistance=15;
    public bool hearingRange;
    public float hearingDistance = 10;

    public Transform target;
   public GameObject resetpos;
    public float followSpeed = 3f;
    public bool start = true;
    public bool disable = false;
    public bool unpause = false;
   

    public float dist;
    public float playerDist;
    //public GameObject other;
    public bool returning = false;
    public int route=1;
    public float rotationSpeed = 0;
    //float lockPos = 0;
    public bool forceContinue = false;



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
        

        if (forceContinue)
        {
            Continue();
        }
        //mittaa etäisyyden pelaajaan
        playerDist = Vector3.Distance(target.transform.position, transform.position);
        if (playerDist >= hearingDistance)
        {
            
            hearingRange = false;
        }
        else if (playerDist < hearingDistance)
        {
            hearingRange = true;
        }


        if (unpause)
         {
             Continue();
             unpause = false;
             Move();

         }
         if (PlayerMovement.pl.pause)
         {
             Stop();
            if (Input.GetKeyDown(KeyCode.P))
            {
                unpause = true;
            }
         } 


        if (!PlayerMovement.pl.pause)
        {

            if (dist <2 && !EnemyFOV.efov.isDetected&& !EnemyFOV.efov.isCautious)
            {
                disable = false;
            }

            if (resetpos)
            {
                dist = Vector3.Distance(resetpos.transform.position, transform.position);
            }
            else
            {
                Debug.Log("resetpositionia ei löydy");
            }
     



            //enemy chase
            if (enemyScript.isDetected == true && playerDist < enemyMaxDistance)
            {
                warningText.SetActive(true);
                disable = true;
                //vanhaa paskakoodia -->
                /*transform.LookAt(target);
                transform.Translate(Vector3.forward * followSpeed * Time.deltaTime); */

                if (target != null)
                {

                    Vector3 dir = target.position - transform.position;
                    // Only needed if objects don't share 'z' value.
                    dir.z = 0.0f;

                    //chase distance check
                    if (playerDist > enemyMinDistance && playerDist < enemyMaxDistance)
                        transform.LookAt(target);

                    transform.rotation = Quaternion.Slerp(transform.rotation,
                            Quaternion.FromToRotation(Vector3.right, dir),
                            rotationSpeed * Time.deltaTime);

                    //Move Towards Target
                    transform.position += (target.position - transform.position).normalized
                        * followSpeed * Time.deltaTime;
                }
                //rigidbody.velocity = Vector3.zero;
            }

        }



            //enemy searching
            if (enemyScript.isCautious == true && enemyScript.isDetected == false && playerDist < enemyMaxDistance)
        {
                transform.Rotate(0, 50 * Time.deltaTime, 0);
                GetComponent<NavMeshAgent>().speed = 0f;
                questionText.SetActive(true);
                warningText.SetActive(false);
                start = false;
                disable = true;
            }
            //enemy continue patrol
            if (!enemyScript.isCautious && !start)
            {

                warningText.SetActive(false);
                questionText.SetActive(false);
                Continue();

            }
        }      
                
        

    

    public void Continue()
    {
        if (dist < 1)
        {
            agent.SetDestination(pos2.position);
            forceContinue = false;
        }

        else if (dist >=1)
        {
            agent.SetDestination(pos1.position);
            forceContinue = false;
        }
        questionText.SetActive(false);
        
        GetComponent<NavMeshAgent>().speed = guardSpeed;
        start = true;
        disable = false;
    }

    public void Stop()
    {
        GetComponent<NavMeshAgent>().speed = 0f;
    }
    public void Move()
    {
        GetComponent<NavMeshAgent>().speed = guardSpeed;
    }


    public void OnTriggerEnter(Collider other)
    {

        
        if (PlayerMovement.pl.pause==false)
        {
            //enemy patrol route 1

            if (disable == false && route==1)
            {
                
                if (other.tag == "1")
                    {
                        agent.SetDestination(pos2.position);
                        start = true;
                    returning = false;
                    }

                    if (other.tag == "2" && !returning)
                    {
                        agent.SetDestination(pos3.position);

                    }

                    if (other.tag == "3")
                    {
                        agent.SetDestination(pos2.position);
                        returning = true;

                    }
                    if (other.tag == "2" && returning)
                    {
                        agent.SetDestination(pos1.position);
                    
                    }
                }
            //enemy patrol route 2

            if (disable == false && route == 2)
            {

                if (other.tag == "1")
                {
                    agent.SetDestination(pos2.position);
                    start = true;
                    returning = false;
                }

                if (other.tag == "2" && !returning)
                {
                    agent.SetDestination(pos3.position);

                }

                if (other.tag == "3" && !returning)
                {
                    agent.SetDestination(pos4.position);
                    

                }
                if (other.tag == "4" && !returning)
                {
                    agent.SetDestination(pos5.position);
                    
                }
                if (other.tag == "5")
                {
                    agent.SetDestination(pos4.position);
                    returning = true;
                }

                if (other.tag=="4" && returning)
                {
                    agent.SetDestination(pos3.position);
                }

                if (other.tag == "3" && returning)
                {
                    agent.SetDestination(pos2.position);
                }

                if (other.tag == "2" && returning)
                {
                    agent.SetDestination(pos1.position);
                    //returning = false;
                }
            }
            //enemy patrol route 3

            if (disable == false && route == 3)
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
                    agent.SetDestination(pos1.position);

                }
            }
            //enemy patrol route 4
            if (disable == false && route == 4)
            {

                if (other.tag == "1")
                {
                    agent.SetDestination(pos2.position);
                    start = true;
                    returning = false;

                }

                if (other.tag == "2" && !returning)
                {
                    agent.SetDestination(pos3.position);

                }

                if (other.tag == "3" && !returning)
                {
                    agent.SetDestination(pos4.position);


                }
                if (other.tag == "4" && !returning)
                {
                    agent.SetDestination(pos5.position);

                }

                if (other.tag == "5")
                {
                    agent.SetDestination(pos1.position);
                    returning = true;

                }

                if (other.tag == "4" && returning)
                {
                    agent.SetDestination(pos3.position);
                }

                if (other.tag == "3" && returning)
                {
                    agent.SetDestination(pos2.position);
                }

                if (other.tag == "2" && returning)
                {
                    agent.SetDestination(pos1.position);
                }

            }




        }
        }
   





    }


        


    







