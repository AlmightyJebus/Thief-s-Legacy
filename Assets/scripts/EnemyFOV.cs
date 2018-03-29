using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public bool isSeen;
    public float borderViewNegative = -23f;
    public float borderViewPositive = 23f;
    public float borderViewLength = 3.3f;

    void Update()
    {

        RaycastHit hit;
        RaycastHit hit2;
        RaycastHit hit3;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 3;
        Quaternion spreadAngleNegative = Quaternion.AngleAxis(borderViewNegative, Vector3.up);
        Quaternion spreadAnglePositive = Quaternion.AngleAxis(borderViewPositive, Vector3.up);

        Debug.DrawRay(transform.position, forward, Color.green);
        Debug.DrawRay(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward) * borderViewLength, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward) * borderViewLength, Color.red);
        
        if (Physics.Raycast(transform.position, (forward), out hit))
        {
            if (hit.collider.tag == "Player")
            {
                isSeen = true;
            }

            else
            {
                isSeen = false;
            }
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAngleNegative * Vector3.forward) * borderViewLength, out hit2))
        {
            if (hit2.collider.tag == "Player")
            {
                isSeen = true;
            }

            else
            {
                isSeen = false;
            }
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(spreadAnglePositive * Vector3.forward) * borderViewLength, out hit3))
        {
            if (hit3.collider.tag == "Player")
            {
                isSeen = true;
            }

            else
            {
                isSeen = false;
            }
        }
    }

    /*
    //vanha script, toimii truehen asti
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
                Gamecontroller.instance.Seen();
            }

            else
            {
                isSeen = false;
            }
        }
    }
    */
}
