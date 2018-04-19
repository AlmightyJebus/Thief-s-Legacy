using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{

	public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void WinScreen()
    {
        SceneManager.LoadScene(2);
    }
    public void LoseScreen()
    {
        SceneManager.LoadScene(3);
    }
    

}
