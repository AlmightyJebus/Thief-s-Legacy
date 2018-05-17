using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodoor1 : MonoBehaviour
{


    public int left = -1;
    public int right = 1;
    public bool opening;
    public bool closing;
    public bool open;
    public float speed = 2;
    public float closingSpeed = 1;


    public Transform door1;
    public Transform door2;

    //public bool start;
    public float startZ;
    public float maxPositionZ = 1.5f;


    void Start()
    {

        startZ = door1.transform.localPosition.z;
    }


    void Update()
    {
        if (open)
        {
            opening = true;
        }
        if (opening)
        {
            door1.transform.Translate(0, -1 * speed * Time.deltaTime, 0);
            door2.transform.Translate(0, left * speed * Time.deltaTime, 0);
        }
        if (closing)
        {
            door1.transform.Translate(0, 1 * closingSpeed * Time.deltaTime, 0);
            door2.transform.Translate(0, right * closingSpeed * Time.deltaTime, 0);
            //start = false;




        }
        //jos ovi on jo auki
        if (door1.transform.localPosition.z >= maxPositionZ && opening)
        {
            Debug.Log(door1.transform.localPosition.z);
            opening = false;
            closing = true;
            open = false;

        }
        //jos ovi on jo kiinni
        if (door1.transform.localPosition.z <= startZ&& closing)
        {

            Debug.Log(door1.transform.localPosition.z);
            opening = false;
            closing = false;
            // start = true;
        }




    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            open = true;
            opening = true;
        }
    }


    // tämä ovikansioon, kansioon lisätään box collider arvoilla: size: 3,4,2, position: z:0.34 (is trigger)


}







