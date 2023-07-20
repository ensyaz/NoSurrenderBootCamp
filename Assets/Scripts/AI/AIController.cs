using System;
using UnityEngine;
using UnityEngine.AI;

public class AIController : AIState
{
    [Header("Attributes")]
    [SerializeField] private float searchRange;

    [Header("LayerMasks")]
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private LayerMask enemyTowerLayer;

    private Collider[] enemyTowerColliders;
    private Collider[] enemySoldierColliders;
    private Animator animator;

    private GameObject nearestTower;

    private float nearestDistance2Tower = float.MaxValue;
    private float nearestDistance2Enemy = float.MaxValue;

    private bool isAttackAnimPlaying;


    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   
        animator = GetComponent<Animator>();    
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Idle:
                Idle();
                break;
            case State.AttackTower:
                AttackTower();
                break;
            case State.AttackEnemy:
                break;
        }
    }

    private void Idle()
    {
        enemySoldierColliders = Physics.OverlapSphere(transform.position, searchRange, attackableLayer);

        if (enemySoldierColliders.Length > 0 ) 
        {
            currentState = State.AttackEnemy;
            return;
        }
        
        enemyTowerColliders = Physics.OverlapSphere(transform.position, float.MaxValue, enemyTowerLayer);

        if (enemyTowerColliders.Length > 0)
        {
            GetNearestTower(enemyTowerColliders);
            currentState = State.AttackTower;
            return;
        }
    }

    private void AttackTower()
    {
        if (!nearestTower.activeInHierarchy)
        {
            currentState = State.Idle;
            return;
        }

        agent.destination = nearestTower.transform.position;
        transform.LookAt(nearestTower.transform);

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            Attack(nearestTower);
    }

    private void AttackEnemy()
    {
        throw new NotImplementedException();
    }

    private void Attack(GameObject obj)
    {
        if (isAttackAnimPlaying) return;
        isAttackAnimPlaying = true;
        animator.SetBool("isAttack", true);
    }

    private void ExitAttack()
    {
        animator.SetBool("isAttack", false);
        isAttackAnimPlaying = false;
    }

    private void GetNearestTower(Collider[] enemyTowerColliders)
    {
        float distance;
        nearestTower = null;
        nearestDistance2Tower = float.MaxValue;

        foreach (Collider col in enemyTowerColliders)
        {
            distance = Vector3.Distance(transform.position, col.transform.position);

            if (distance < nearestDistance2Tower)
            {
                nearestDistance2Tower = distance;
                nearestTower = col.gameObject;
            }
        }
    }
}
