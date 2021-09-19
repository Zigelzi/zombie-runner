using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float CurrentHealth { get { return currentHealth; } }

    [SerializeField] [Range(1, 500f)] float maxHealth = 100f;
    [SerializeField] float currentHealth;

    DeathHandler deathHandler;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        deathHandler = FindObjectOfType<DeathHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died!");
        deathHandler.HandleDeath();
    }
}
