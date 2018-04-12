using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSphere : MonoBehaviour {

    public bool detection = false;
    public float radius = 10f;

    void Start()
    {

    }

    void Update()
    {
        if (PlayerMovement.pl.isStolen)
        {
            SphereCollider myCollider = transform.GetComponent<SphereCollider>();
            myCollider.radius = 2.5f; 
        }
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
