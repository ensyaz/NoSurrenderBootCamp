using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hitPoint;

    private EnemyPool enemyPool;

    private float currentHitPoint;

    [SerializeField] private float speed;

    private void Awake()
    {
        enemyPool = GetComponentInParent<EnemyPool>();
    }

    private void OnEnable()
    {
        currentHitPoint = hitPoint;
    }

    // Update is called once per frame
    void Update()
    {
       if (currentHitPoint <= 0)
        {
            enemyPool.disabledEnemyCount++;
            gameObject.SetActive(false);
        }
            

        Move();
    }

    private void Move()
    {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }

    public void GetHit(float takenDamage)
    {
        currentHitPoint -= takenDamage;
    }
}
