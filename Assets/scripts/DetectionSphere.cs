using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSphere : MonoBehaviour {

    public bool isHeard = false;
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

        if (isHeard == true && PlayerMovement.pl.isMoving)
        {
            EnemyFOV.efov.isDetected = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Player") && PlayerMovement.pl.isSprinting && PlayerMovement.pl.isMoving)
        {
            isHeard = true;

            
            EnemyFOV.efov.noiseTimer = true;
            
        }

        if (col.CompareTag("Player") && !PlayerMovement.pl.isSprinting)
        {
            isHeard = false;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player") && PlayerMovement.pl.isSprinting && PlayerMovement.pl.isMoving)
        {
            isHeard = true;
            EnemyFOV.efov.noiseTimer = true;
        }

        if (col.CompareTag("Player"))
        {
            isHeard = false;
        }
    }
}
