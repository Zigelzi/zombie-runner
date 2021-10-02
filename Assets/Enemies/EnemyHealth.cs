using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    int hitPoints = 100;
    bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead) { return; }

        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Animator animator = GetComponent<Animator>();
        EnemyAI enemyAI = GetComponent<EnemyAI>();
        NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        
        enemyAI.enabled = false;
        animator.SetTrigger("die");
        navMeshAgent.enabled = false;

        isDead = true;
    }
}
