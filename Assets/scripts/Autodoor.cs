using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodoor : MonoBehaviour
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
    public float startX;
    public float maxPositionX = 1.5f;


    void Start()
    {

        startX = door1.transform.localPosition.x;
    }


    void Update()
    {
        if (!PlayerMovement.pl.pause)
        {
            if (open)
            {
                opening = true;
            }
            if (opening)
            {
                door1.transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
                door2.transform.Translate(left * speed * Time.deltaTime, 0, 0);
            }
            if (closing)
            {
                door1.transform.Translate(1 * closingSpeed * Time.deltaTime, 0, 0);
                door2.transform.Translate(right * closingSpeed * Time.deltaTime, 0, 0);
                //start = false;


            }
            //jos ovi on jo auki
            if (door1.transform.localPosition.x >= maxPositionX && opening)
            {
                Debug.Log(door1.transform.localPosition.x);
                opening = false;
                closing = true;
                open = false;

            }
            //jos ovi on jo kiinni
            if (door1.transform.localPosition.x <= startX && closing)
            {

                Debug.Log(door1.transform.localPosition.x);
                opening = false;
                closing = false;
                // start = true;
            }

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





