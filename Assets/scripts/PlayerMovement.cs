using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    public float speed = 2f;
    public bool gameOn;
    public Text winText;
    public Text loseText;
    

    void Start ()
    {
        gameOn = true;
	}

	void Update ()
    {
        if (gameOn)
        {

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.back * speed * Time.deltaTime;
            }
        }
        else
        {
            return;
        }



    }
    void OnTriggerEnter(Collider other)

    {

        if (other.gameObject.CompareTag("Loot"))
        {
           
            other.gameObject.SetActive(false);
            //Gamecontroller.instance.Win();
            

            gameOn = false;


        }

        if (other.gameObject.CompareTag ("Enemy"))
        {
           
            gameOn = false;
            //Gamecontroller.instance.Lose();
        }
        
    }

    
}
