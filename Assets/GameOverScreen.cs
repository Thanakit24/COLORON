using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public PlayerController player;

    public GameObject gameOverUI;
    
    void OnEnable()
    {
        player.OnDeath += GameOverCanvas;
    }

    void OnDisable()
    {
        player.OnDeath -= GameOverCanvas;
    }

    void GameOverCanvas()
    {
        Debug.Log("Canvas");
        gameOverUI.SetActive(true);
    }
    public void LoadMenu()
    {
        Debug.Log("Loading menu");
        SceneManager.LoadScene("StartMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
