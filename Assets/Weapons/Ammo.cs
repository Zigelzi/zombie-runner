using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public int amount;
        public int magSize;
        public AmmoType ammoType;

        public bool MagFull()
        {

            if (amount >= magSize)
            {
                return true;
            } else
            {
                return false;
            }
    }
    }

    public bool HasAmmo(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);

        if (ammoSlot.amount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Consume(AmmoType ammoType)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);
        if (HasAmmo(ammoType))
        {
            ammoSlot.amount--;
        }
    }

    AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }

    

    public void Refill(AmmoType ammoType, int amount)
    {
        AmmoSlot ammoSlot = GetAmmoSlot(ammoType);

        if (!ammoSlot.MagFull())
        {
            ammoSlot.amount += amount;
        }
    }
}
