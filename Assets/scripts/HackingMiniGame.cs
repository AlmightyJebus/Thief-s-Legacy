using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackingMiniGame : MonoBehaviour
{
    // LAITA OBJEKTIIN JOKA HAKKEROIDAAN!!
    // LAITA AKTIVOITUMAAN KUN HAKKEROINTI ALKAA!!
    // KATSO SAMALLA EnemyFOV.efov.detectionPercent JA isSolved TOIMINTA!!

    public PlayerMovement playerscript;
    public bool isSolved = false;
    public bool isHacking = false;
    public float solvingTime = 10f;
    public float defaultSolvingTime = 10f;
    public float timerbarconverter;
    public static HackingMiniGame miniGame;
    public GameObject hackBoard;
    public Image hacktimer;
    public Image progressbar;
    public float multiplier;
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
        miniGame = this;
        hacktimer.GetComponent<Image>().enabled = true;
        timerbarconverter = 1f / solvingTime;

    }

    void Update()
    {

        if (!PlayerMovement.pl.pause)
        {
            if (HackableObject.hackable.isHackable == true && Input.GetKey(KeyCode.E))
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
            }

            if (isSolved == true)
            {
                PlayerMovement.pl.speed = PlayerMovement.pl.defaultSpeed;
                isHacking = false;
                lightQ.SetActive(false);
                lightE.SetActive(false);
                hackBoard.SetActive(false);
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
                    lightF.SetActive(false);
                    lightA.SetActive(false);
                    lightR.SetActive(false);
                    lightW.SetActive(false);
                    lightD.SetActive(false);
                    lightS.SetActive(false);
                    lightE.SetActive(false);
                    progressbar.fillAmount = 0f;
                }

                //Minipeli alkaa...
                if (Input.GetKey(sequenceFirst[sequenceIndex]))
                {

                    if (++sequenceIndex == sequenceFirst.Length)
                    {
                        isSolved = true;
                        //Tähän tulee mitä tapahtuu, kun minipeli ratkaistaan
                        sequenceIndex = 0;
                    }

                    if (sequenceIndex > 0)
                    {
                        lightQ.SetActive(false);

                        multiplier = sequenceIndex + 1;
                        Fill();
                    }

                    if (sequenceIndex == 1)
                    {
                        lightF.SetActive(true);
                        multiplier = sequenceIndex + 1;
                        Fill();

                    }

                    if (sequenceIndex == 2)
                    {
                        lightF.SetActive(false);
                        lightA.SetActive(true);
                        multiplier = sequenceIndex + 1;
                        Fill();
                    }

                    if (sequenceIndex == 3)
                    {
                        lightA.SetActive(false);
                        lightR.SetActive(true);
                        multiplier = sequenceIndex + 1;
                        Fill();
                    }

                    if (sequenceIndex == 4)
                    {
                        lightR.SetActive(false);
                        lightW.SetActive(true);
                        multiplier = sequenceIndex + 1;
                        Fill();
                    }

                    if (sequenceIndex == 5)
                    {
                        lightW.SetActive(false);
                        lightD.SetActive(true);
                        multiplier = sequenceIndex + 1;
                        Fill();
                    }

                    if (sequenceIndex == 6)
                    {
                        lightD.SetActive(false);
                        lightS.SetActive(true);
                        multiplier = sequenceIndex + 1;
                        Fill();
                    }

                    if (sequenceIndex == 7)
                    {
                        lightS.SetActive(false);
                        lightE.SetActive(true);
                        multiplier = sequenceIndex + 1;
                        Fill();
                    }
                }

                else if (Input.anyKeyDown && sequenceIndex > 0)
                {
                    isSolved = false;
                    EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + 25f;
                    sequenceIndex = 0;
                    progressbar.fillAmount = 0;
                }
            }

            if (solvingTime < 0)
            {
                //Mitä tapahtuu kun minigamen ratkaisuaika loppuu :D
                EnemyFOV.efov.detectionPercent = EnemyFOV.efov.detectionPercent + 25f;
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
        progressbar.fillAmount = multiplier * 0.085f;
    }
}
        
    
