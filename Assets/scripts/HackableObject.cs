using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HackableObject : MonoBehaviour
{
    // LAITA OBJEKTIIN JOKA HAKKEROIDAAN!!
    // LAITA AKTIVOITUMAAN KUN HAKKEROINTI ALKAA!!
    // KATSO SAMALLA EnemyFOV.efov.detectionPercent JA isSolved TOIMINTA!!

    public bool isHackable = false;
    public static HackableObject hackable;
    public GameObject hackText;

    public void Start()
    {
        hackable = this;
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
        }

        else
        {
            isHackable = false;
            hackText.SetActive(false);
        }
    }
}