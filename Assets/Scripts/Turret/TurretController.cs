using UnityEngine;

public class TurretController : TurretState
{
    [Header("Attributes")]
    [SerializeField] private float attackRange;
    [SerializeField] private float fireRate;
    [SerializeField] private float bulletSpeed;

    [Header("Prefabs")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Components")]
    [SerializeField] private Transform muzzleTransform;
    [SerializeField] private BulletPool bulletPool;

    private GameObject nearestEnemy;
    private LayerMask enemyLayer;
    private float nearestDistance = float.MaxValue;
    private float attackCounter;
    private int bulletCounter;

    private void Awake()
    {
        enemyLayer = LayerMask.GetMask("Enemy");
        attackCounter = fireRate;
    }

    private void Update()
    {
        if (currentState == State.Search)
        {
            SearchEnemy();
        }
        else if (currentState == State.Attack)
        {
            AttackEnemy();
        }
    }

    private void SearchEnemy()
    {
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        if (enemyColliders.Length > 0)
        {
            GetNearestEnemy(enemyColliders);
            currentState = State.Attack;
        }
        
    }

    private void AttackEnemy()
    {
        if (!nearestEnemy.activeInHierarchy)
        {
            currentState = State.Search;
            Debug.Log(nearestEnemy.name);
        }
            

        transform.LookAt(nearestEnemy.transform);

        if (attackCounter >= fireRate)
        {
            // Reset counter
            attackCounter = 0f;

            if (bulletCounter >= bulletPool.bulletObjects.Length)
                bulletCounter = 0;

            bulletPool.bulletObjects[bulletCounter].SetActive(true);
            bulletPool.bulletObjects[bulletCounter].GetComponent<Rigidbody>().AddForce(muzzleTransform.forward * bulletSpeed, ForceMode.Impulse);
            bulletCounter++;
            // GameObject bulletObj = Instantiate(bulletPrefab, muzzleTransform, false);
            // bulletObj.GetComponent<Rigidbody>().AddForce(muzzleTransform.forward * bulletSpeed, ForceMode.Impulse);
        }
        else
        {
            attackCounter += Time.deltaTime;
        }
    }

    private void GetNearestEnemy(Collider[] enemyColliders)
    {
        float distance;

        foreach (Collider col in enemyColliders)
        {
            distance = Vector3.Distance(transform.position, col.transform.position);

            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = col.gameObject;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
