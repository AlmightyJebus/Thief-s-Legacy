using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingMiniGame : MonoBehaviour
{
    // LAITA OBJEKTIIN JOKA HAKKEROIDAAN!!
    // LAITA AKTIVOITUMAAN KUN HAKKEROINTI ALKAA!!
    // KATSO SAMALLA EnemyFOV.efov.detectionPercent JA isSolved TOIMINTA!!

    public bool isSolved = false;
    public bool isHacking = false;
    public static HackingMiniGame miniGame;

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

    private int sequenceIndex;

    void Start()
    {
        miniGame = this;
    }

    void Update()
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
        }

        if (isSolved == true)
        {
            PlayerMovement.pl.speed = PlayerMovement.pl.defaultSpeed;
            isHacking = false;
        }

        if (isHacking == true)
        {
            //Minipeli alkaa...
            if (Input.GetKey(sequenceFirst[sequenceIndex]))
            {
                if (++sequenceIndex == sequenceFirst.Length)
                {
                    isSolved = true;
                    //Tähän tulee mitä tapahtuu, kun minipeli ratkaistaan
                    sequenceIndex = 0;
                }

                if (sequenceIndex == 1)
                {
                    //sytytä Q
                }

                if (sequenceIndex == 2)
                {
                    //sammuta Q
                    //sytytä F
                }

                if (sequenceIndex == 3)
                {
                    //sytytä A
                }

            }

            else if (Input.anyKeyDown && sequenceIndex > 0)
            {
                isSolved = false;
                sequenceIndex = 0;
                EnemyFOV.efov.detectionPercent = +25f;
            }
        }
    }
}
