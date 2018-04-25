using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackableObjectSecond : MonoBehaviour
{
    // LAITA OBJEKTIIN JOKA HAKKEROIDAAN!!
    // LAITA AKTIVOITUMAAN KUN HAKKEROINTI ALKAA!!
    // KATSO SAMALLA EnemyFOV.efov.detectionPercent JA isSolved TOIMINTA!!

    public bool isHackable = false;
    public static HackableObjectSecond hackableSecond;
    public GameObject hackText;
    public GameObject hackCompletedText;

    public void Start()
    {
        hackableSecond = this;
    }

    public void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1f))
        {
            if (hit.collider.tag == "Player")
            {
                isHackable = true;
                hackText.SetActive(true);
            }

            if (hit.collider.tag == "Player" && HackingMiniGameSecond.miniGameSecond.isHacking == true)
            {
                hackText.SetActive(false);
            }

            if (isHackable == true && HackingMiniGameSecond.miniGameSecond.isSolved == true)
            {
                hackText.SetActive(false);
            }
        }

        else
        {
            isHackable = false;
            hackText.SetActive(false);
        }
    }
}