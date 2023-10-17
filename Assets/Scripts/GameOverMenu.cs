using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    
    public void MainMenu()
    { 
        SceneController.isPaused = false;
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneController.isPaused = false;
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
}
