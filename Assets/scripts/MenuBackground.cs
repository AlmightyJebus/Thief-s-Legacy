using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour
{
    public GameObject background;
    public GameObject withTreasure;
    public GameObject withoutTreasure;
    public bool isStolen = false;
    public float backgroundTimerVisible = 15f;
    public float backgroundTimerNotVisible = 5f;
    
	void Update ()
    {
        backgroundTimerVisible = backgroundTimerVisible - Time.deltaTime;

		if (isStolen == false)
        {
            background.SetActive(false);
            withTreasure.SetActive(true);
            withoutTreasure.SetActive(false);
        }

        if (isStolen == true)
        {
            withTreasure.SetActive(false);
            background.SetActive(true);
        }

        if (backgroundTimerVisible <= 0)
        {
            isStolen = true;
            backgroundTimerNotVisible = backgroundTimerNotVisible - Time.deltaTime;
        }

        if (backgroundTimerNotVisible <= 0)
        {
            background.SetActive(false);
            withoutTreasure.SetActive(true);
        }
    }
}
