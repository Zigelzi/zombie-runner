using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    GameOverUIManager gameOverUiManager;
    // Start is called before the first frame update
    void Start()
    {
        gameOverUiManager = FindObjectOfType<GameOverUIManager>();
    } 

    public void HandleDeath()
    {
        gameOverUiManager.DisplayGameOverCanvas(true);
    }
}
