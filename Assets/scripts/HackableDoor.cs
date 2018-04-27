using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackableDoor : MonoBehaviour
{
    // LAITA OBJEKTIIN JOKA HAKKEROIDAAN!!
    // LAITA AKTIVOITUMAAN KUN HAKKEROINTI ALKAA!!
    // KATSO SAMALLA EnemyFOV.efov.detectionPercent JA isSolved TOIMINTA!!

    public bool isHackableDoor = false;
    public static HackableDoor hackableDoor;
    public GameObject hackText;
    public Transform transformDoor;
    public Transform player;
    public float distance;
    public float minDistance = 1.5f;

    public void Start()
    {
        hackableDoor = this;
    }

    public void FixedUpdate()
    {
        distance = Vector3.Distance(transformDoor.position, player.position);

        if (distance < minDistance)
        {
            isHackableDoor = true;
            hackText.SetActive(true);
        }

        if (distance > minDistance)
        {
            isHackableDoor = false;
            hackText.SetActive(false);
        }

        if (HackingMiniGameDoor.hackingDoor.isHacking == true)
        {
            hackText.SetActive(false);
        }

        if (HackingMiniGameDoor.hackingDoor.isSolved == true)
        {
            hackText.SetActive(false);
        }
    }
}
