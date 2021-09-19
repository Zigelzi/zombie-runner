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

        // Ensure that the canvas is off at start and mouse cursor is locked
        DisplayGameOverCanvas(false);
        DisplayMouseCursor(false);

    }

    public void DisplayGameOverCanvas(bool canvasVisibility)
    {
        gameOverCanvas.enabled = canvasVisibility;
    }

    public void DisplayMouseCursor(bool cursorVisibility)
    {
        if (cursorVisibility == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
