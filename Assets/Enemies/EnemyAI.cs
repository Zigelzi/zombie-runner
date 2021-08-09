using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] [Range(0, 20f)] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    Vector3 lastPosition = Vector3.zero;
    float movementSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            target = player.transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isProvoked)
        {
            EngageTarget();
        } 
        else if (IsTargetInChaseRange())
        {
            isProvoked = true;
            ChaseTarget();
        }
        
    }

    void OnDrawGizmosSelected()
    {
        DisplayChaseRange();
    }

    void EngageTarget()
    {
        movementSpeed = CalculateSpeed();

        if (!IsTargetInAttackRange())
        {
            StopAttacking();
            ChaseTarget();
        }

        if (IsTargetInAttackRange())
        {
            AttackTarget();
        }
    }

    bool IsTargetInChaseRange()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= chaseRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
        PlayMovementAnimation();
    }

    void PlayMovementAnimation()
    {
        animator.SetFloat("movementSpeed", movementSpeed);
    }

    float CalculateSpeed()
    {
        Vector3 currentPosition = transform.position;
        float movementSpeed = (currentPosition - lastPosition).magnitude / Time.fixedDeltaTime;
        lastPosition = transform.position;
        return movementSpeed;
    }

    bool IsTargetInAttackRange()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        Debug.Log(distanceToTarget);
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void AttackTarget()
    {
        animator.SetBool("attack", true);
    }

    void StopAttacking()
    {
        animator.SetBool("attack", false);
    }

    void DisplayChaseRange()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
