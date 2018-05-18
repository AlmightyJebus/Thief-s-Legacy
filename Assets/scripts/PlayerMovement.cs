using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{



    [HideInInspector]
    public float detectionValue;
    public float detectionBarConverter;
    [HideInInspector]
    public float speed = 2f;
    public float diagonalSlowdownValue = 2f;

    public float defaultSpeed = 2f;
    [HideInInspector]
    public float slowdownValue = 1;

    public float sprintSpeed = 4f;
    //[HideInInspector]
    public float stamina = 10f;
    public float staminaValue = 5;


    //bools
    public bool pause = false;
    public bool reduceStamina = false;
    public bool increaseStamina = false;

    public bool isMoving = false;
    public bool isCrouching = false;
    public bool isSprinting = false;
    public bool atTheWall = false;
    public bool isStolen = false;
    public bool gotit = false;

    public GameObject winText, loot, pickable1, pickable2, pickable3, pickable4;
    public GameObject pauseText, losescreen, winscreen, pausemenu;
    public Image picked1, picked2, picked3, picked4, looted, staminaBar, criticalMeter;


    //scripts
    [HideInInspector]
    public static PlayerMovement pl;
    public Patroller Patrollerscript;

    [HideInInspector]
    public HackingMiniGame hackingscript;
    [HideInInspector]
    public EnemyFOV enemyFOVscript;
    [HideInInspector]
    public Gamecontroller Gamecontrolscript;





    void Awake()
    {
        picked1.GetComponent<Image>().enabled = false;
        picked2.GetComponent<Image>().enabled = false;
        picked3.GetComponent<Image>().enabled = false;
        picked4.GetComponent<Image>().enabled = false;
        looted.GetComponent<Image>().enabled = false;
        stamina = staminaValue;
        speed = defaultSpeed;

    }

    void Start()
    {
        pl = this;

        Gamecontroller.instance.timerOn = true;
        Debug.Log("Clear");
    }


    void FixedUpdate()
    {
        //Speed normalizers
        if (!pause)
        {
            //Diagonal speed normalizer
            if (!isCrouching && !isSprinting && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                speed = defaultSpeed / diagonalSlowdownValue;
            }
            else if (isSprinting && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
            {
                speed = sprintSpeed / diagonalSlowdownValue;
            }
            else if (isCrouching)
            {
                speed = 0;
            }
            else if (isSprinting)
            {
                speed = sprintSpeed;
            }

            else
            {
                speed = defaultSpeed;
            }

            

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
                        //crouchText.SetActive(true);
                        speed = 0;

                    }

                    if (isCrouching == false)
                    {
                        //animation change in the future
                        //crouchText.SetActive(false);
                        //speed = defaultSpeed;

                    }
                }

                //if not at the wall you can quit crouching
                if (!atTheWall)
                {
                    if (isCrouching)
                    {
                        isCrouching = false;
                        //crouchText.SetActive(false);
                        //speed = defaultSpeed;

                    }
                }
            }


        }



    }
    void Update()
    {

        //MAIN MENU
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }







        //PAUSE
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;

            if (pause)
            {
                Debug.Log("PAUSE");
                pause = true;
                //Patroller.patr.disable = true;

                pausemenu.SetActive(true);

            }
            else if (!pause)
            {
                pause = false;
                Debug.Log("UNPAUSE");

                //Patroller.patr.unpause = true;

                pausemenu.SetActive(false);
            }
        }

        // PELI ALKAA
        if (!pause)
        {

            //critical meter kasvaa jos..
            criticalMeter.fillAmount = Gamecontroller.instance.criticalPercent / detectionBarConverter;
            detectionValue = Gamecontroller.instance.criticalPercent;

            //check if lose
            if (criticalMeter.fillAmount == 1)
            {
                Lose();
            }

            // MUU MÖNJÄ!!!

            if (gotit && isCrouching)
            {
                speed = 0;
            }
            //stamina checks
            if (increaseStamina && stamina <= staminaValue)
            {
                stamina += 0.5f * Time.deltaTime;
                if (staminaBar.fillAmount < 1)
                {
                    staminaBar.fillAmount += 0.5f / staminaValue * Time.deltaTime;
                }
                if (stamina >= staminaValue)
                {
                    increaseStamina = false;
                    stamina = staminaValue;
                }

            }
            if (reduceStamina && stamina > 0)
            {
                stamina -= 1 * Time.deltaTime;
                if (staminaBar.fillAmount > 0)
                {
                    staminaBar.fillAmount -= 1 / staminaValue * Time.deltaTime;
                }
                Debug.Log(staminaBar.fillAmount);
                if (stamina <= 0)
                {
                    isSprinting = false;
                    staminaBar.fillAmount = 0;
                    stamina = 0;
                    Debug.Log("Out of stamina");
                    speed = defaultSpeed;
                    //sprintText.SetActive(false);


                }
            }


           

            // sprinting
            if (Input.GetKey(KeyCode.LeftShift) && stamina > 0 && !isCrouching)
            {
                isSprinting = true;
                isMoving = true;
                //sprintText.SetActive(true);
                speed = sprintSpeed;
                reduceStamina = true;

            }

            //sprinting ends
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isSprinting = false;
                isMoving = false;
                //sprintText.SetActive(false);
                speed = defaultSpeed;
                reduceStamina = false;
                increaseStamina = true;


            }
            //moving
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                isMoving = true;
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                isMoving = true;
                transform.position += Vector3.right * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                isMoving = true;
                transform.position += Vector3.forward * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                isMoving = true;
                transform.position += Vector3.back * speed * Time.deltaTime;
            }

            if (!Input.anyKey && Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                isMoving = false;
            }
            if (!Input.anyKey && Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                isMoving = false;
            }
            if (!Input.anyKey && Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
            {
                isMoving = false;
            }
            if (!Input.anyKey && Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
            {
                isMoving = false;
            }

        }





}

    

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            atTheWall = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Loot") && HackingMiniGame.hacking1.isSolved)
        {

            loot.SetActive(false);
            looted.GetComponent<Image>().enabled = true;
            gotit = true;
            Gamecontroller.instance.AddLoot();
            Gamecontroller.instance.AddScore();
            isStolen = true;
        }

        //exit with primary loot
        if (other.gameObject.CompareTag("Exit") && gotit)
        {
            Exit();
            Win();

        }

        if (other.gameObject.CompareTag("Pickable1"))
        {
            pickable1.SetActive(false);
            picked1.GetComponent<Image>().enabled = true;
            Gamecontroller.instance.AddLoot();
            Gamecontroller.instance.AddScore();

        }


        if (other.gameObject.CompareTag("Pickable2"))
        {
            pickable2.SetActive(false);
            picked2.GetComponent<Image>().enabled = true;
            Gamecontroller.instance.AddLoot();
            Gamecontroller.instance.AddScore();

        }
        if (other.gameObject.CompareTag("Pickable3"))
        {
            pickable3.SetActive(false);
            picked3.GetComponent<Image>().enabled = true;
            Gamecontroller.instance.AddLoot();
            Gamecontroller.instance.AddScore();

        }
        if (other.gameObject.CompareTag("Pickable4"))
        {
            pickable4.SetActive(false);
            picked4.GetComponent<Image>().enabled = true;
            Gamecontroller.instance.AddLoot();
            Gamecontroller.instance.AddScore();

        }

    }



    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            atTheWall = false;
        }
    }
    public void Lose()
    {
        losescreen.SetActive(true);
        pause = true;
        Gamecontroller.instance.successTime = 0;
        Gamecontroller.instance.lootProcent = 1;
        Gamecontroller.instance.CountMeter();
        Gamecontroller.instance.ScoreLoot();
        Gamecontroller.instance.CountTime();
        Gamecontroller.instance.ShowScore();
    }
    public void Win()
    {
        winscreen.SetActive(true);
        pause = true;
        Gamecontroller.instance.ShowScore();

    }
    public void Exit()
    {
        Gamecontroller.instance.CountMeter();
        Gamecontroller.instance.ScoreLoot();
        Gamecontroller.instance.CountTime();
        Gamecontroller.instance.ResetTime();
        Gamecontroller.instance.Exit();
    }
    // laita scenet buildiin uudestaan mainmenu level1 ja level2..
}
