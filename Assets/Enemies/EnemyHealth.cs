using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int hitPoints = 100;

    public void TakeDamage(int damage)
    {

        hitPoints -= damage;
        Debug.Log($"Health after taking damage: {hitPoints}");

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
