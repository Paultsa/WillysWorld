using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RngEnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public float moveRadius = 20f;

    public float attackDistance = 8f;
    public Animator enemyAnim;

    private Vector3 lastPosition;
    private Vector3 startPosition;

    Transform target;
    NavMeshAgent agent;

    // Use this for initialization
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        lastPosition = transform.position;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        float distance2 = Vector3.Distance(startPosition, transform.position);

        bool isInRadius = distance2 < moveRadius;

        if (distance <= attackDistance && isInRadius)
        {
            Debug.Log("Attack");
            agent.SetDestination(target.position);
        }
        else if (distance <= lookRadius && isInRadius)
        {
            agent.SetDestination(target.position);
        }
        else if (!isInRadius)
        {
            agent.SetDestination(startPosition);
        }
        else
        {
            StopEnemy();
        }

        float dispSpeed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
        lastPosition = transform.position;

        enemyAnim.SetBool("isAttacking", (distance < attackDistance));
        enemyAnim.SetFloat("isRunning", dispSpeed);

    }

    public void StopEnemy()
    {
        agent.SetDestination(transform.position);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(startPosition, moveRadius);
    }
}