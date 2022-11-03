using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public bool gameHasEnded = false;

    public float restartDelay = 0.5f;

    public GameObject completeLevelUI;

    public PlayerController player;

    public void CompleteLevel()
    {
        Debug.Log("Completing Level");
        completeLevelUI.SetActive(true);
    }

    void OnEnable()
    {
        player.OnDeath += EndGame;
    }

    void OnDisable()
    {
        player.OnDeath -= EndGame;
    }
    public void EndGame()
    {
        Debug.Log("Death working");
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
        }
    }

    // Update is called once per frame
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
