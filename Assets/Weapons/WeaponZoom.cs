using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] float zoomInFOV = 20f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomOutSensitivity = 2f;

    [SerializeField] bool zoomedIn = false;

    RigidbodyFirstPersonController playerController;
    Camera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        playerController = FindObjectOfType<RigidbodyFirstPersonController>();
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
            playerCamera.fieldOfView = zoomInFOV;
            playerController.mouseLook.XSensitivity = zoomInSensitivity;
            playerController.mouseLook.YSensitivity = zoomInSensitivity;

            zoomedIn = true;
        }
        else
        {
            playerCamera.fieldOfView = zoomOutFOV;
            playerController.mouseLook.XSensitivity = zoomOutSensitivity;
            playerController.mouseLook.YSensitivity = zoomOutSensitivity;

            zoomedIn = false;
        }
    }
}
