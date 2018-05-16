using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public bool pause = false;
    public GameObject pauseText;
    public GameObject losescreen;
    public GameObject winscreen;
    public GameObject pausemenu;

    public float detectionValue;
    public float detectionBarConverter;
    public float speed = 2f;
    public float normalHeight = 2f;
    private float crouchHeight = 1f;
    private float defaultSpeed = 2f;
    private float slowdownValue = 1;
    public float normalValue = 1.5f;
    public float sprintSpeed = 4f;
    public float stamina = 10f;
    private bool gameOn;
    public bool reduceStamina = false;
    public bool increaseStamina = false;
    public GameObject winText;
    public GameObject loot;
    public GameObject pickable1, pickable2, pickable3, pickable4;
    public Image picked1, picked2, picked3, picked4, looted;
    public GameObject crouchText;
    public GameObject sprintText;
    //public GameObject staminaText;
    public Image staminaBar;
    public Image criticalMeter;
    //public Image hacktimer;

    //public Text loseText;
    public bool isMoving = false;
    public bool isCrouching = false;
    public bool isSprinting = false;
    public bool atTheWall = false;
    public bool isStolen = false;
    public bool gotit = false;
    public static PlayerMovement pl;
    Patroller Patrollerscript;
    public CapsuleCollider pCollider;
    public HackingMiniGame hackingscript;
    public EnemyFOV enemyFOVscript;
    public Gamecontroller Gamecontrolscript;
    //public Transform other;
    //public float enemydist;

    void Awake()
    {
        picked1.GetComponent<Image>().enabled = false;
        picked2.GetComponent<Image>().enabled = false;
        picked3.GetComponent<Image>().enabled = false;
        picked4.GetComponent<Image>().enabled = false;
        looted.GetComponent<Image>().enabled = false;

    }

    void Start ()
    {
        pl = this;
        gameOn = true;
        pCollider = GetComponent<CapsuleCollider>();
        //hacktimer.GetComponent<Image>().enabled = true;
        Gamecontroller.instance.timerOn = true;
        Debug.Log("Clear");
    }

    void Update()
    {
        //enemydist = Vector3.Distance(other.position, transform.position);

        //MAIN MENU
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

      /*  if (Input.GetKeyDown(KeyCode.T))
        {
            hacktimer.GetComponent<Image>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            hacktimer.GetComponent<Image>().enabled = false;
        }

        */

        //PAUSE
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;

            if (pause)
            {
                Debug.Log("PAUSE");
                pause = true;
                Patroller.patr.disable = true;
                //pauseText.SetActive(true);
                pausemenu.SetActive(true);

            }
            else if (!pause)
            {
                pause = false;
                Debug.Log("UNPAUSE");
                
                Patroller.patr.unpause = true;
                //Patroller.patr.start = true;
                //pauseText.SetActive(false);
                pausemenu.SetActive(false);
            }
        }

        // PELI ALKAA
        if (!pause)
        {

            
            
            //critical meter kasvaa jos..
            criticalMeter.fillAmount = Gamecontroller.instance.criticalPercent/detectionBarConverter;
            detectionValue = Gamecontroller.instance.criticalPercent;

            //check if lose
            if (criticalMeter.fillAmount == 1)
            {
                Lose();
            }




            if (reduceStamina)
            {
                stamina -= 1 * Time.deltaTime;
                staminaBar.fillAmount -= 0.2f * Time.deltaTime;
            }

            if (increaseStamina)
            {
                if (stamina <= 10)
                {
                    stamina += 0.5f * Time.deltaTime;
                    staminaBar.fillAmount += 0.5f/10.5f * Time.deltaTime;

                    if (stamina >= 10)
                    {
                        stamina = 10f;
                        staminaBar.fillAmount = 1;
                        Debug.Log("FULL STAMINA");
                        //staminaText.SetActive(false);
                    }
                    
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
                            //pCollider.height = crouchHeight;
                        }

                        if (isCrouching == false)
                        {
                            //animation change in the future
                            crouchText.SetActive(false);
                            speed = normalValue;
                           // pCollider.height = normalHeight;
                        }
                    }

                    //if not at the wall you can quit crouching
                    if (!atTheWall)
                    {
                        if (isCrouching)
                        {
                            isCrouching = false;
                            crouchText.SetActive(false);
                            speed = normalValue;
                            //pCollider.height = normalHeight;
                        }
                    }
                }

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    isSprinting = true;
                    isMoving = true;
                    sprintText.SetActive(true);
                    speed = sprintSpeed;
                    reduceStamina = true;

                    if (stamina < 0)
                    {
                        isSprinting = false;
                        speed = normalValue;
                        sprintText.SetActive(false);
                        Debug.Log("OUT OF STAMINA");
                        //staminaText.SetActive(true);
                    }
                }

                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    isSprinting = false;
                    sprintText.SetActive(false);
                    speed = normalValue;
                    reduceStamina = false;
                    increaseStamina = true;
                    isSprinting = false;
                }

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
                /*
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }*/
            }
        }



    }


    
   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            atTheWall = true;
        }

        if (other.gameObject.CompareTag("Loot") && HackingMiniGame.hacking1.isSolved)
        {
           // winText.SetActive(true);
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

        // lose condition
       if (other.gameObject.CompareTag ("Enemy"))
          
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //Lose();
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

}
