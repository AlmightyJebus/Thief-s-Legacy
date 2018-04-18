using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingMiniGame : MonoBehaviour {

    // LAITA OBJEKTIIN JOKA HAKKEROIDAAN!!
    // LAITA AKTIVOITUMAAN KUN HAKKEROINTI ALKAA!!
    // KATSO SAMALLA EnemyFOV.efov.detectionPercent JA isSolved TOIMINTA!!

    bool isSolved = false;

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

    private void Update()
    {
        if (Input.GetKeyDown(sequenceFirst[sequenceIndex]))
        {
            if (++sequenceIndex == sequenceFirst.Length)
            {
                isSolved = true;
                //Tähän tulee mitä tapahtuu, kun minipeli ratkaistaan
                sequenceIndex = 0;
            }
        }

        else if (Input.anyKeyDown && sequenceIndex > 0)
        {
            isSolved = false;
            sequenceIndex = 0;
            EnemyFOV.efov.detectionPercent =+ 25f;
        }
    }
}
