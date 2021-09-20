using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int amount = 5;
    public int Amount { get { return amount; } }
    
    public bool HasAmmo()
    {
        if (amount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Consume()
    {
        if (HasAmmo())
        {
            amount--;
        }
    }
}
