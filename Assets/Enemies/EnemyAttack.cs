using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] [Range(0, 100f)] float attackDamage = 20f;
    EnemyAI ai;
    Player player;
    PlayerHealth playerHealth;

    void Start()
    {
        player = FindObjectOfType<Player>();
        playerHealth = player.GetComponent<PlayerHealth>();
        ai = GetComponent<EnemyAI>();
    }

    void Update()
    {
        HandleAttack();
    }

    void HandleAttack()
    {
        if (ai.IsTargetInAttackRange())
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    void DamagePlayer()
    {
        Debug.Log($"Damaged player for {attackDamage}!");
    }
}
