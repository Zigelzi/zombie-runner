using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayGameOverCanvas(bool canvasVisibility) {
        gameOverCanvas.enabled = canvasVisibility;
    }
}
