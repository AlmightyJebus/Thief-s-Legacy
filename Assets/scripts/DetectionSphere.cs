using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionSphere : MonoBehaviour {

    public bool Detection = false;

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player") && PlayerMovement.pl.isSprinting)
        {
            Detection = true;
        }

        //:D
    }
}
