using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAnimator : MonoBehaviour
{
    public Animator animGuard;
    public static GuardAnimator animatorGuard;
    public float rotationValue;
    public bool A, S, D, W;
    private NavMeshAgent agent;
    public Vector2 dir;
   // public bool south;
   // public bool west;
   // public bool east;
   // public bool north;

    void Start ()
    {
        animatorGuard = this;
        animGuard = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
	
	void Update ()
    {
        // dir = (agent.nextPosition - transform.position).normalized;
        // Debug.Log("Dir: " + agent.nextPosition + " TR: "+ transform.position);
       // Debug.Log("Dir: " + transform.forward);

       // toisenlainen suunnantarkistus, turha :)
        /* if (transform.forward.x >=0 && transform.forward.z >= 0 )
        {
            south = true;
            west = false;
            east = false;
            north = false;
        }
        if (transform.forward.x <= 0 && transform.forward.z >=0)
        {
            south = false;
            west = false;
            east = true;
            north = false;
        
        }
        if (transform.forward.x >=0 && transform.forward.z <=0)
        {
            south = false;
            west = true;
            east = false;
            north = false;
        }
        if (transform.forward.x <=0 && transform.forward.z <=0)
        {
            south = false;
            west = false;
            east = false;
            north = true;
        } */
        if (PlayerMovement.pl.pause)
        {
            animGuard.SetBool("A", false);
            animGuard.SetBool("S", false);
            animGuard.SetBool("D", false);
            animGuard.SetBool("W", false);
        }
        if (!PlayerMovement.pl.pause)
        {
            rotationValue = transform.localEulerAngles.y;
            //GuardWalkA = nyt S
            //
            if (rotationValue >= 225 && rotationValue <= 315 || rotationValue >= -135 && rotationValue <= -45)
            {
                A = false;
                S = true;
                D = false;
                W = false;
                animGuard.SetBool("A", false);
                animGuard.SetBool("S", true);
                animGuard.SetBool("D", false);
                animGuard.SetBool("W", false);
            }

            //GuardWalkS = nyt A
            if (rotationValue >= 135 && rotationValue <= 225 || rotationValue >= -225 && rotationValue <= -135)
            {
                A = true;
                S = false;
                D = false;
                W = false;
                animGuard.SetBool("A", true);
                animGuard.SetBool("S", false);
                animGuard.SetBool("D", false);
                animGuard.SetBool("W", false);
            }

            //GuardWalkD
            if (rotationValue >= 45 && rotationValue <= 135 || rotationValue >= 405 && rotationValue <= 495)
            {
                A = false;
                S = false;
                D = true;
                W = false;
                animGuard.SetBool("A", false);
                animGuard.SetBool("S", false);
                animGuard.SetBool("D", true);
                animGuard.SetBool("W", false);
            }

            //GuardWalkW
            if (rotationValue >= 315 && rotationValue <= 405 || rotationValue >= -45 && rotationValue <= 45)
            {
                A = false;
                S = false;
                D = false;
                W = true;
                animGuard.SetBool("A", false);
                animGuard.SetBool("S", false);
                animGuard.SetBool("D", false);
                animGuard.SetBool("W", true);
            }
        }
    }
           

           
    
        
}