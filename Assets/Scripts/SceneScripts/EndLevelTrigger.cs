using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{

    public GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Triggering Level Complete");
        gameManager.CompleteLevel();
    }

    
}
