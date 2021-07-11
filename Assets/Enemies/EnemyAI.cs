using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] [Range(0, 20f)] float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
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
        if (!IsTargetInAttackRange())
        {
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
    }

    bool IsTargetInAttackRange()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

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
        Debug.Log("Reeee!");
    }

    void DisplayChaseRange()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
