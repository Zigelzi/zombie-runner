using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float zoomInValue = 20f;
    [SerializeField] float zoomOutValue = 60f;
    [SerializeField] bool zoomedIn = false;

    Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            HandleZoom();
        }
    }

    void HandleZoom()
    {
        if (!zoomedIn)
        {
            SetZoomIn(true);
        }
        else
        {
            SetZoomIn(false);
        }
    }

    void SetZoomIn(bool enableZoom)
    {
        if (enableZoom)
        {
            playerCamera.fieldOfView = zoomInValue;
            zoomedIn = true;
        }
        else
        {
            playerCamera.fieldOfView = zoomOutValue;
            zoomedIn = false;
        }
    }
}
