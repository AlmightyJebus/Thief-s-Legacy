using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameWon = false;
    public static Gamecontroller instance;
    public float score = 0;
    public int items = 0;
    public Text scoreText;
    public GameObject scoreTextDisplay;
    public GameObject timeTextDisplay;
    public Text itemText;
    public Text timeText;
    public GameObject itemTextDisplay;
    public GameObject gameOverText;
    public GameObject winText;
    public PlayerMovement playerscript;
    public EnemyFOV enemyFOVscript;
    public Patroller patrollerscript;
    public float criticalPercent;
    public float lootProcent;
    public float lootMultiplier;
    public float successTime;
    public float completionTime;
    public bool timerOn = false;

        

    void Awake()
    {
        //onko muuttunut GIT
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        lootProcent = 1f;
        successTime = 100f;
    }

	void Update ()

        
    {
        if (!PlayerMovement.pl.pause)
        {
            if (timerOn)
            {
                Timer();
            }
        }
        
	}

    public void ShowScore()
    {
        score = Mathf.RoundToInt(score);
        if (score<0)
        {
            score = 0;
        }
        scoreTextDisplay.SetActive(true);
        scoreText.text = "SCORE: " + score.ToString();
        timeTextDisplay.SetActive(true);
        timeText.text = "TIME: " + completionTime.ToString();


        timerOn = false;
    }

   
    public void CountMeter()
    {

        if (PlayerMovement.pl.criticalMeter.fillAmount <= 0.1f)
        {
            score +=500;
        }


        if (PlayerMovement.pl.criticalMeter.fillAmount <= 0.3f)
        {
            score +=300;
        }
        
        if (PlayerMovement.pl.criticalMeter.fillAmount<=0.5f)
        {
            score +=100;
        }
        
    }
    public void Hack()
    {
        score += 100f;
    }
    public void HackFail()
    {
        score -= 30;
    }
    public void AddLoot()
    {
        lootProcent += lootMultiplier;
    }
    public void ScoreLoot()
    {
        score = score * lootProcent;
    }
    public void CountTime()
    {
        score +=successTime;
    }
    public void AddScore()
    {
        score += 10;
    }
    public void ResetTime()
    {
        successTime = 100f;
    }
    public void Lose()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
    public void Win()
    {
        winText.SetActive(true);
        gameOver = true;
    }
    public void Exit()
    {
        score += 50f;
    }
    public void Timer()
    {
        successTime -= Time.deltaTime;
        if (successTime <0)
        {
            successTime = 0;
        }
    }
    public void Seen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Items()
    {
        items++;
    }
    public void ShowItems()
    {
       itemTextDisplay.SetActive(true);
       itemText.text = "SCORE: " + score.ToString();
    }
    public void SuccessTime()
    {
        completionTime = 100f - successTime;
    }
}
