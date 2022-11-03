using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }


   
    public void Back()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
