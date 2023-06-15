using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : DontDestroy<GameManager>
{
    public void LobbyScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GameStop()
    {
        Time.timeScale = 0;
    }
    public void GameScene()
    {
        SceneManager.LoadScene(2);
    }
    public void GameContinue()
    {
        Time.timeScale = 1;
    }
    public void GameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOff()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
