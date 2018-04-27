using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingMiniGameDoor : MonoBehaviour
{
    // LAITA OBJEKTIIN JOKA HAKKEROIDAAN!!
    // LAITA AKTIVOITUMAAN KUN HAKKEROINTI ALKAA!!
    // KATSO SAMALLA EnemyFOV.efov.detectionPercent JA isSolved TOIMINTA!!

    public PlayerMovement playerscript;
    public static HackingMiniGameDoor hackingDoor;
    public bool isSolved = false;
    public bool isHacking = false;
    public float solvingTime;
    public float defaultSolvingTime;
    public float timerbarconverter;
    public static HackingMiniGameDoor miniGameDoor;
    public GameObject hackBoard;
    public Image hacktimer;
    public Image progressbar;
    public float multiplier;
    public float count;
    public Text countText;
    public float waitTime = 1f;
    public bool wait = false;
    public bool waitover = false;


    public GameObject lightQ, lightW, lightE, lightR, lightT, lightA, lightS, lightD, lightF, lightG, lightZ, lightX, lightC, lightV, lightB;

    //1st sequence - Q R W E Q W E R

    private KeyCode[] sequenceFirst = new KeyCode[]{
    KeyCode.Q,
    KeyCode.R,
    KeyCode.W,
    KeyCode.E,
    KeyCode.Q,
    KeyCode.W,
    KeyCode.E,
    KeyCode.R
    };

    public int sequenceIndex;

    void Start()
    {
        miniGameDoor = this;
        hacktimer.GetComponent<Image>().enabled = true;
        timerbarconverter = 1f / solvingTime;
        hackingDoor = this;
    }

    void Update()
    {
        if (!PlayerMovement.pl.pause)
        {
            //wait
            if (wait)
            {
                //Debug.Log("Timer");
                waitTime -= Time.deltaTime;

                if (waitTime < 0)
                {
                    //Debug.Log("Time over");
                    waitover = true;
                    waitTime = 2f;
                    wait = false;
                }
            }

            if (HackableDoor.hackableDoor.isHackableDoor == true && Input.GetKey(KeyCode.E))
            {
                PlayerMovement.pl.speed = 0;
                isHacking = true;
            }

            if (isHacking == true && Input.GetKey(KeyCode.Backspace))
            {
                //Minipelistä pääsee pois
                PlayerMovement.pl.speed = PlayerMovement.pl.defaultSpeed;
                isHacking = false;
                hackBoard.SetActive(false);
                //hacktimer.GetComponent<Image>().enabled = false;
                solvingTime = defaultSolvingTime;
                sequenceIndex = 0;
                lightQ.SetActive(false);
                lightW.SetActive(false);
                lightE.SetActive(false);
                lightR.SetActive(false);
            }

            if (isSolved == true)
            {
                isHacking = false;
                PlayerMovement.pl.speed = PlayerMovement.pl.defaultSpeed;

                if (waitover == true)
                {
                    lightQ.SetActive(false);
                    lightR.SetActive(false);
                    hackBoard.SetActive(false);
                    waitover = false;
                }

                //hacktimer.GetComponent<Image>().enabled = false;
                solvingTime = defaultSolvingTime;
            }

            if (isHacking == true)
            {
                hackBoard.SetActive(true);
                hacktimer.GetComponent<Image>().enabled = true;
                solvingTime = solvingTime - Time.deltaTime;
                hacktimer.fillAmount -= timerbarconverter * Time.deltaTime;

                if (sequenceIndex == 0)
                {
                    lightQ.SetActive(true);
                    lightW.SetActive(false);
                    lightE.SetActive(false);
                    lightR.SetActive(false);
                    progressbar.fillAmount = 0f;
                    count = 0;
                    countText.text = count.ToString() + " %";
                }

                //Minipeli alkaa...
                if (Input.GetKey(sequenceFirst[sequenceIndex]))
                {
                    if (++sequenceIndex == sequenceFirst.Length)
                    {
                        Debug.Log("SOLVED!");
                        //Tähän tulee mitä tapahtuu, kun minipeli ratkaistaan
                        wait = true;
                        Full();
                        Gamecontroller.instance.Hack();
                        isSolved = true;
                        sequenceIndex = 0;
                    }
                    
                    if (sequenceIndex > 0)
                    {
                        Debug.Log("0");
                        lightQ.SetActive(false);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 1)
                    {
                        Debug.Log("1");
                        lightR.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 2)
                    {
                        lightR.SetActive(false);
                        lightW.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 3)
                    {
                        lightW.SetActive(false);
                        lightE.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 4)
                    {
                        lightE.SetActive(false);
                        lightQ.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 5)
                    {
                        lightQ.SetActive(false);
                        lightW.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 6)
                    {
                        lightW.SetActive(false);
                        lightE.SetActive(true);
                        Fill();
                    }

                    if (sequenceIndex == 7)
                    {
                        lightE.SetActive(false);
                        lightR.SetActive(true);
                        Fill();
                    }
                }
                //FAIL
                else if (Input.anyKeyDown && sequenceIndex > 0)
                {
                    Gamecontroller.instance.HackFail();
                    isSolved = false;
                    EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + 25f;
                    sequenceIndex = 0;
                    progressbar.fillAmount = 0;
                    count = 0;
                    countText.text = count.ToString() + " %";
                }
            }

            if (solvingTime < 0)
            {
                //Mitä tapahtuu kun minigamen ratkaisuaika loppuu :D
                EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + 25f;
                solvingTime = defaultSolvingTime;
                Gamecontroller.instance.HackFail();
                isHacking = false;
                hackBoard.SetActive(false);
                sequenceIndex = 0;
                lightQ.SetActive(false);
                lightW.SetActive(false);
                lightE.SetActive(false);
                lightR.SetActive(false);
                PlayerMovement.pl.speed = PlayerMovement.pl.defaultSpeed;
            }
        }
    }

    public void Fill()
    {
        multiplier = sequenceIndex;
        progressbar.fillAmount = multiplier * 0.125f;
        count = multiplier * 12.5f;
        countText.text = count.ToString() + " %";
    }

    public void Full()
    {
        Debug.Log("FULL!");
        progressbar.fillAmount = 1f;
        count = 100;
        countText.text = count.ToString() + " %";
    }

    public void Wait()
    {

    }
}
