using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed = 2f;
    public bool gameOn;
    public GameObject winText;
    public GameObject loot;
    public Text loseText;
    public bool isCrouching = false;
    public bool atTheWall = false;
    

    void Start ()
    {
        gameOn = true;
	}

	void Update ()
    {
        if (gameOn)
        {

            //crouching
            if (Input.GetKey(KeyCode.C))
            {

                if (atTheWall)
                {
                    //toggle crouching
                    isCrouching = !isCrouching;
                    if (isCrouching)
                    {
                        //animation change in the future
                        return;
                    }
                    else
                    {
                        //animation change in the future
                        return;
                    }
                }

                //if not at the wall you can quit crouching
                if (!atTheWall)
                {
                    if(isCrouching)
                    {
                        isCrouching = false;
                    }
                }

            }
            

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
            if (Input.GetKey(KeyCode.R))
                {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            

        }
        else
        {
            return;
        }



    }
    void OnTriggerEnter(Collider other)

    {


        if (other.gameObject.CompareTag("Wall"))
        {
            atTheWall = true;
        }

        if (other.gameObject.CompareTag("Loot"))
        {

            winText.SetActive(true);
            loot.SetActive(false);
            
        }

        if (other.gameObject.CompareTag ("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            atTheWall = false;
        }
    }

    
}
