using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverUIManager : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas").GetComponent<Canvas>();

        // Ensure that the canvas is off at start
        DisplayGameOverCanvas(false);
    }

    public void DisplayGameOverCanvas(bool canvasVisibility)
    {
        gameOverCanvas.enabled = canvasVisibility;
    }
}
