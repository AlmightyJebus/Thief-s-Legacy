using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed = 2f;
    public float slowdownValue = 1;
    public float normalValue = 1.5f;
    public float sprintSpeed = 4f;
    public float stamina = 10f;
    public bool gameOn;
    public bool reduceStamina = false;
    public bool increaseStamina = false;
    public GameObject winText;
    public GameObject loot;
    public GameObject crouchText;
    public GameObject sprintText;
    public GameObject staminaText;

    public Text loseText;
    public bool isCrouching = false;
    public bool isSprinting = false;
    public bool atTheWall = false;
    public static PlayerMovement pl;

    void Start ()
    {
        pl = this;
        gameOn = true;
	}

	void Update ()
    {


        if (reduceStamina)
        {
            stamina -= 2 * Time.deltaTime;
        }

        if (increaseStamina)
        {
            
            if (stamina <=10)
            {
                stamina += Time.deltaTime;

                if (stamina >10)
                {
                    stamina = 10f;
                }
                //staminaText.SetActive(false);
            }
        }

        if (stamina < 0)
        {
            isSprinting = false;
            speed = normalValue;
            sprintText.SetActive(false);
            //staminaText.SetActive(true);
            reduceStamina = false;
            increaseStamina = true;
        }

        if (gameOn)
        {

            //crouching
            if (Input.GetKeyDown(KeyCode.C))
            {

                if (atTheWall)
                {
                    //toggle crouching
                    isCrouching = !isCrouching;
                    if (isCrouching)
                    {
                        //animation change in the future
                        crouchText.SetActive(true);
                        speed = slowdownValue;
                    }
                    if (isCrouching == false)
                    {
                        //animation change in the future
                        crouchText.SetActive(false);
                        speed = normalValue;
                    }
                }

                //if not at the wall you can quit crouching
                if (!atTheWall)
                {
                    if(isCrouching)
                    {
                        isCrouching = false;
                        crouchText.SetActive(false);
                        speed = normalValue;
                    }
                }

                

            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSprinting = !isSprinting;
                if (isSprinting)
                {
                    sprintText.SetActive(true);
                    speed = sprintSpeed;
                    reduceStamina = true;
                    if (stamina < 0)
                    {
                        isSprinting = false;
                        speed = normalValue;
                        sprintText.SetActive(false);
                        staminaText.SetActive(true);
                    }

                }
                if (isSprinting == false)
                {
                    sprintText.SetActive(false);
                    speed = normalValue;
                    reduceStamina = false;

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
