using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public bool isSeen;
    
    //toimii truehen asti
    void Update()
    {
        RaycastHit hit;
        
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            if(hit.collider.tag == "Player")
            {
                isSeen = true;
            }

            else
            {
                isSeen = false;
            }
        }
    }
}
