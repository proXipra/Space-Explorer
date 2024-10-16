using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuScript : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Quit();
    }

}
