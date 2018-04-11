using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFOV : MonoBehaviour
{
    public bool isSeen = false;
    public float cameraBorderViewNegative = -23f;
    public float cameraBorderViewPositive = 23f;
    public float viewLength = 3;

    void FixedUpdate()
    {

        transform.Rotate(0, 30 * Time.deltaTime, 0);
        
        

        RaycastHit hit;
        RaycastHit hit2;
        RaycastHit hit3;

        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
        Quaternion spreadAngleNegative = Quaternion.AngleAxis(cameraBorderViewNegative, Vector3.up);
        Quaternion spreadAnglePositive = Quaternion.AngleAxis(cameraBorderViewPositive, Vector3.up);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, viewLength))
        {
            if (hit.collider.tag == "Player")
            {
                isSeen = true;
            }

            if (hit.collider.tag != "Player")
            {
                isSeen = false;
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward), out hit2, viewLength))
        {
            if (hit2.collider.tag == "Player")
            {
                isSeen = true;
            }

            if (hit2.collider.tag != "Player")
            {
                isSeen = false;
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward), out hit3, viewLength))
        {
            if (hit3.collider.tag == "Player")
            {
                isSeen = true;
            }

            if (hit3.collider.tag != "Player")
            {
                isSeen = false;
            }
        }
    }
}