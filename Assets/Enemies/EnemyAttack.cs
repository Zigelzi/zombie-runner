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

    }

    void DamagePlayerHitEvent()
    {
        // Called from the animation event
        if (playerHealth == null || ai == null) { return;  }
        if (ai.IsTargetInAttackRange())
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
