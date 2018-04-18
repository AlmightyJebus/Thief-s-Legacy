using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackableObject : MonoBehaviour
{
    public bool isHackable = false;

    public static HackableObject hackable;

    public void Start()
    {
        hackable = this;
    }

	public void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f))
        {
            if (hit.collider.tag == "Player")
            {
                isHackable = true;
            }
        }

        else
        {
            isHackable = false;
        }
    }
}