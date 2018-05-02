using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingMiniGameSecond : MonoBehaviour
{
    // LAITA OBJEKTIIN JOKA HAKKEROIDAAN!!
    // LAITA AKTIVOITUMAAN KUN HAKKEROINTI ALKAA!!
    // KATSO SAMALLA EnemyFOV.efov.detectionPercent JA isSolved TOIMINTA!!

    public PlayerMovement playerscript;
    public bool isSolved = false;
    public bool isHacking = false;
    public float solvingTime;
    public float defaultSolvingTime;
    public float timerbarconverter;
    public static HackingMiniGameSecond miniGameSecond;
    public GameObject hackBoard;
    public Image hacktimer;
    public Image progressbar;
    public float multiplier;
    public float count;
    public Text countText;
    public float waitTime = 2f;
    public bool wait = false;
    public bool waitover = false;

    public GameObject lightQ, lightW, lightE, lightR, lightT, lightA, lightS, lightD, lightF, lightG, lightZ, lightX, lightC, lightV, lightB;

    //1st sequence - Q F A R W D S E

    private KeyCode[] sequenceFirst = new KeyCode[]{
    KeyCode.Q,
    KeyCode.F,
    KeyCode.A,
    KeyCode.R,
    KeyCode.W,
    KeyCode.D,
    KeyCode.S,
    KeyCode.E
    };

    public int sequenceIndex;

    void Start()
    {
        miniGameSecond = this;
        hacktimer.GetComponent<Image>().enabled = true;
        timerbarconverter = 1f / solvingTime;
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

            if (HackableObjectSecond.hackableSecond.isHackable == true && Input.GetKey(KeyCode.E))
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
                lightF.SetActive(false);
                lightA.SetActive(false);
                lightR.SetActive(false);
                lightW.SetActive(false);
                lightD.SetActive(false);
                lightS.SetActive(false);
                lightE.SetActive(false);
                Reset();
            }

            if (isSolved == true)
            {
                isHacking = false;
                PlayerMovement.pl.speed = PlayerMovement.pl.defaultSpeed;
                if (waitover == true)
                {
                    lightQ.SetActive(false);
                    lightE.SetActive(false);
                    hackBoard.SetActive(false);
                    waitover = false;
                }

                //hacktimer.GetComponent<Image>().enabled = false;
                solvingTime = defaultSolvingTime;
            }

            if (isHacking == true)
            {
                PlayerMovement.pl.speed = 0;
                PlayerAnimator.animator.anim.SetBool("A", false);
                PlayerAnimator.animator.anim.SetBool("W", false);
                PlayerAnimator.animator.anim.SetBool("D", false);
                PlayerAnimator.animator.anim.SetBool("S", false);
                hackBoard.SetActive(true);
                hacktimer.GetComponent<Image>().enabled = true;
                solvingTime = solvingTime - Time.deltaTime;
                hacktimer.fillAmount -= timerbarconverter * Time.deltaTime;

                if (sequenceIndex == 0)
                {
                    lightQ.SetActive(true);
                    lightF.SetActive(false);
                    lightA.SetActive(false);
                    lightR.SetActive(false);
                    lightW.SetActive(false);
                    lightD.SetActive(false);
                    lightS.SetActive(false);
                    lightE.SetActive(false);
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
                        Gamecontroller.instance.Hack();
                        wait = true;
                        Full();
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
                        lightF.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();

                    }

                    if (sequenceIndex == 2)
                    {
                        lightF.SetActive(false);
                        lightA.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 3)
                    {
                        lightA.SetActive(false);
                        lightR.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 4)
                    {
                        lightR.SetActive(false);
                        lightW.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 5)
                    {
                        lightW.SetActive(false);
                        lightD.SetActive(true);
                        multiplier = sequenceIndex;
                        Fill();
                    }

                    if (sequenceIndex == 6)
                    {
                        lightD.SetActive(false);
                        lightS.SetActive(true);

                        Fill();
                    }

                    if (sequenceIndex == 7)
                    {
                        lightS.SetActive(false);
                        lightE.SetActive(true);
                        Fill();
                    }
                }
                //FAIL
                else if (Input.anyKeyDown && sequenceIndex > 0)
                {
                    Gamecontroller.instance.HackFail();
                    isSolved = false;
                    Gamecontroller.instance.criticalPercent = Gamecontroller.instance.criticalPercent + 10f;
                    sequenceIndex = 0;
                    progressbar.fillAmount = 0;
                    count = 0;
                    countText.text = count.ToString() + " %";
                }
            }

            if (solvingTime < 0)
            {
                //Mitä tapahtuu kun minigamen ratkaisuaika loppuu :D
                Gamecontroller.instance.HackFail();
                Gamecontroller.instance.criticalPercent = Gamecontroller.instance.criticalPercent + 10f;
                solvingTime = defaultSolvingTime;
                isHacking = false;
                hackBoard.SetActive(false);
                sequenceIndex = 0;
                lightQ.SetActive(false);
                lightF.SetActive(false);
                lightA.SetActive(false);
                lightR.SetActive(false);
                lightW.SetActive(false);
                lightD.SetActive(false);
                lightS.SetActive(false);
                lightE.SetActive(false);
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

    public void Reset()
    {
        hacktimer.fillAmount = 1;
        solvingTime = defaultSolvingTime;
    }
}