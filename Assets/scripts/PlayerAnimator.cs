using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    public Animator anim;
    public static PlayerAnimator animator;
    public PlayerMovement playerscript;

	void Start ()
    {
        animator = this;
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
       
        if (PlayerMovement.pl.pause)
        {
            anim.SetBool("A", false);
            anim.SetBool("W", false);
            anim.SetBool("S", false);
            anim.SetBool("D", false);
            anim.SetBool("Crouch", false);
        }
        if (!PlayerMovement.pl.pause)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                anim.SetBool("A", true);
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                anim.SetBool("A", false);
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("S", true);
            }

            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                anim.SetBool("S", false);
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                anim.SetBool("D", true);
            }

            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                anim.SetBool("D", false);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetBool("W", true);
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                anim.SetBool("W", false);
            }

            if (anim.GetBool("A") && anim.GetBool("W"))
            {
                anim.SetBool("A", true);
                anim.SetBool("W", false);
            }

            if (anim.GetBool("W") && anim.GetBool("D"))
            {
                anim.SetBool("W", true);
                anim.SetBool("D", false);
            }

            if (anim.GetBool("D") && anim.GetBool("S"))
            {
                anim.SetBool("D", true);
                anim.SetBool("S", false);
            }

            if (anim.GetBool("S") && anim.GetBool("A"))
            {
                anim.SetBool("S", true);
                anim.SetBool("A", false);
            }

            if (anim.GetBool("A") && anim.GetBool("D"))
            {
                anim.SetBool("A", false);
                anim.SetBool("D", false);
            }

            if (anim.GetBool("W") && anim.GetBool("S"))
            {
                anim.SetBool("W", false);
                anim.SetBool("S", false);
            }

            if (PlayerMovement.pl.isCrouching == true && PlayerMovement.pl.atTheWall == true)
            {
                anim.SetBool("Crouch", true);
            }

            if (PlayerMovement.pl.isCrouching == false)
            {
                anim.SetBool("Crouch", false);
            }
        }

            
        }
        

    
}