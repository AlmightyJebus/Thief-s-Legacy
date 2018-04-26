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
    private int score = 0;
    public Text scoreText;
    public GameObject gameOverText;
    public GameObject winText;
    public PlayerMovement playerscript;
    public EnemyFOV enemyFOVscript;
    public Patroller patrollerscript;
    public float criticalPercent;

        

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

    // Use this for initialization
  
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void Score()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Score: " + score.ToString() + "/40";


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
    public void Seen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
