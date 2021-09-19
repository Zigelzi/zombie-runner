using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    DeathHandler deathHandler;

    void Start()
    {
        deathHandler = FindObjectOfType<DeathHandler>();    
    }
    public void RestartGame()
    {
        deathHandler.DisplayGameOverCanvas(false);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        if (Application.isPlaying)
        {
            Application.Quit();
        }
    }
}
