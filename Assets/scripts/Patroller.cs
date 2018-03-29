using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patroller : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;
    public Transform pos7;
    public Transform pos8;




    public NavMeshAgent agent;
    

	// Use this for initialization
	void Start ()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    private void OnTriggerEnter(Collider other)
    {

        
            if (other.tag == "1")
            {
                agent.SetDestination(pos2.position);
            
           
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
