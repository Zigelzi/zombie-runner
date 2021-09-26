using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] PickupType pickupType;
    [SerializeField] AmmoType ammoType;
    [SerializeField] int pickupAmount = 1;

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Picked up a pickup!");
            if (pickupType == PickupType.Ammo)
            {
                Ammo ammo = other.gameObject.GetComponent<Ammo>();
                if (ammo == null) { return; }

                ammo.Refill(ammoType, pickupAmount);

            }
            
            Destroy(gameObject);
        }    
    }
}
