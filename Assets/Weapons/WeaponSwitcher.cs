using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    private void Start()
    {
        SetWeaponActive();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            weaponIndex++;
        }  
    }

    void ProcessInput()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessMouseWheelInput();

        if (previousWeapon != currentWeapon)
        {
            SetWeaponActive();
        }

    }

    void ProcessKeyInput()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            currentWeapon = 2;
        }
    }

    void ProcessMouseWheelInput()
    {
        // Scrolling up
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            ChangeWeaponForwards();
        }

        // Scrolling down
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            ChangeWeaponBackwards();
        }
    }

    void ChangeWeaponForwards()
    {
        // Loop back to first weapon if at last weapon index
        if (currentWeapon >= transform.childCount - 1)
        {
            currentWeapon = 0;
        }

        else
        {
            currentWeapon++;
        }
    }
    
    void ChangeWeaponBackwards()
    {
        // Loop back to last weapon if at first weapon index
        if (currentWeapon <= 0)
        {
            currentWeapon = transform.childCount - 1;
        }

        else
        {
            currentWeapon--;
        }
    }
}
