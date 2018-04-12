using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSphere : MonoBehaviour {

    public bool detection = false;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") && PlayerMovement.pl.isSprinting && PlayerMovement.pl.isMoving)
        {
            detection = true;
        }

        if (col.CompareTag("Player") && !PlayerMovement.pl.isSprinting)
        {
            detection = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player") && PlayerMovement.pl.isSprinting && PlayerMovement.pl.isMoving)
        {
            detection = true;
        }

        if (col.CompareTag("Player"))
        {
            detection = false;
        }
    }
}
