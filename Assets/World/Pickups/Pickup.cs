﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] PickupType pickupType;
    [SerializeField] AmmoType ammoType;
    [SerializeField] int pickupAmount = 1;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Picked up a pickup!");
            if (pickupType == PickupType.Ammo)
            {
                Ammo ammo = collision.gameObject.GetComponent<Ammo>();
                ammo.Refill(ammoType, pickupAmount);

            }
            
            Destroy(gameObject);
        }    
    }
}
