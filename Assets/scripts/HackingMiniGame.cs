using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour {

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
            }
        }

        else if (Input.anyKeyDown)
        {
            isSolved = false; //?
            sequenceIndex = 0;
            EnemyFOV.efov.detectionPercent =+ 25f;
        }
    }
}
