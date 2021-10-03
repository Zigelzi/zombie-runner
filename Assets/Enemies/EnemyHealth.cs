using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    int hitPoints = 100;
    bool isDead = false;

    public bool IsDead { get { return isDead; } }

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
        PlayDeathAnimation();

        isDead = true;
    }

    void PlayDeathAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger("die");
    }

}
