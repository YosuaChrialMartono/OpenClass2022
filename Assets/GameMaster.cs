using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    public GameObject gameStartCanvas;
    public GameObject gameOverCanvas;
    public GameObject scoreCanvas;

    private void Start()
    {
        Time.timeScale = 0;
        gameStartCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        scoreCanvas.SetActive(false);
        
    }

    public void GameStart()
    {
        gameStartCanvas.SetActive(false);
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

}
