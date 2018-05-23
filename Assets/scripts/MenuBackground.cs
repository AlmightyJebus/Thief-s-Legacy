using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour
{
    public GameObject background;
    public GameObject withTreasureBlue;
    public GameObject withTreasureRed;
    public GameObject withTreasureGreen;
    public GameObject withoutTreasure;
    public bool one, two, three;
    public float firstTimer;
    public float secondTimer;
    public float thirdTimer;

    void Start()
    {
        firstTimer = 40f;
        secondTimer = 40f;
        thirdTimer = 40f;
        one = true;
    }

    void Update()
    {
        if (one)
        {
            TimerOne();
        }

        if (two)
        {
            TimerTwo();
        }

        if (three)
        {
            TimerThree();
        }
    }

    public void TimerOne()
    {
        //timer 1
        three = false;
        thirdTimer = 40f;
        firstTimer = firstTimer - Time.deltaTime;

        if (firstTimer < 40f && firstTimer > 25f)
        {
            withTreasureBlue.SetActive(true);
        }

        if (firstTimer < 25f && firstTimer > 20f)
        {
            withTreasureBlue.SetActive(false);
            background.SetActive(true);
        }

        if (firstTimer < 20f && firstTimer > 5f)
        {
            background.SetActive(false);
            withoutTreasure.SetActive(true);
        }

        if (firstTimer < 5f && firstTimer > 0f)
        {
            withoutTreasure.SetActive(false);
            background.SetActive(true);
        }

        if (firstTimer <= 0f)
        {
            background.SetActive(false);
            two = true;
        }
    }

    public void TimerTwo()
    {
        //timer 2
        one = false;
        firstTimer = 40f;
        secondTimer = secondTimer - Time.deltaTime;
        
        if (secondTimer < 40f && secondTimer > 25f)
        {
            withTreasureRed.SetActive(true);
        }

        if (secondTimer < 25f && secondTimer > 20f)
        {
            withTreasureRed.SetActive(false);
            background.SetActive(true);
        }

        if (secondTimer < 20f && secondTimer > 5f)
        {
            background.SetActive(false);
            withoutTreasure.SetActive(true);
        }

        if (secondTimer < 5f && secondTimer > 0f)
        {
            withoutTreasure.SetActive(false);
            background.SetActive(true);
        }

        if (secondTimer <= 0f)
        {
            background.SetActive(false);
            thirdTimer = 40f;
            three = true;
        }
    }

    public void TimerThree()
    {
        two = false;
        secondTimer = 40f;
        thirdTimer = thirdTimer - Time.deltaTime;

        if (thirdTimer < 40f && thirdTimer > 25f)
        {
            withTreasureGreen.SetActive(true);
        }

        if (thirdTimer < 25f && thirdTimer > 20f)
        {
            withTreasureGreen.SetActive(false);
            background.SetActive(true);
        }

        if (thirdTimer < 20f && thirdTimer > 5f)
        {
            background.SetActive(false);
            withoutTreasure.SetActive(true);
        }

        if (thirdTimer < 5f && thirdTimer > 0f)
        {
            withoutTreasure.SetActive(false);
            background.SetActive(true);
        }

        if (thirdTimer <= 0f)
        {
            background.SetActive(false);
            firstTimer = 40f;
            one = true;
        }
    }
}
