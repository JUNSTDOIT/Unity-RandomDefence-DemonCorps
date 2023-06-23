using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : DontDestroy<GameManager>
{
    bool _gameOver = false;
    public bool _GameOver => _gameOver;
    bool _gameStop = false;
    public bool _GameStop => _gameStop;
    public void GameOver()
    {
        _gameOver = true;
        Time.timeScale = 0;
    }
    public void LobbyScene()
    {
        Time.timeScale = 1;
        _gameOver = false;
        _gameStop = false;
        SceneManager.LoadScene(1);
    }
    public void GameStop()
    {
        _gameStop = true;
        Time.timeScale = 0;
    }
    public void GameScene()
    {
        Time.timeScale = 1;
        _gameOver = false;
        _gameStop = false;
        SceneManager.LoadScene(2);
    }
    public void GameContinue()
    {
        _gameStop = false;
        Time.timeScale = 1;
    }
    public void GameRestart()
    {
        Time.timeScale = 1;
        _gameOver = false;
        _gameStop = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameOff()
    {
        Time.timeScale = 1;
        Application.Quit();
    }
}
