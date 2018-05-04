using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAnimator : MonoBehaviour
{
    public Animator animGuard;
    public static GuardAnimator animatorGuard;
    public float rotationValue;
    public bool A, S, D, W;

    void Start ()
    {
        animatorGuard = this;
        animGuard = GetComponent<Animator>();
	}
	
	void Update ()
    {
        rotationValue = transform.localEulerAngles.y;
        
        //GuardWalkA
		if (rotationValue >= 225 && rotationValue <= 315 || rotationValue >= -135 && rotationValue <= -45)
        {
            A = true;
            S = false;
            D = false;
            W = false;
            animGuard.SetBool("A", true);
        }

        //GuardWalkS
        if (rotationValue >= 135 && rotationValue <= 225 || rotationValue >= -225 && rotationValue <= -135)
        {
            A = false;
            S = true;
            D = false;
            W = false;
            animGuard.SetBool("S", true);
        }

        //GuardWalkD
        if (rotationValue >= 45 && rotationValue <= 135 || rotationValue >= 405 && rotationValue <= 495)
        {
            A = false;
            S = false;
            D = true;
            W = false;
            animGuard.SetBool("D", true);
        }

        //GuardWalkW
        if (rotationValue >= 315 && rotationValue <= 405 || rotationValue >= -45 && rotationValue <= 45)
        {
            A = false;
            S = false;
            D = false;
            W = true;
            animGuard.SetBool("W", true);
        }
    }
}