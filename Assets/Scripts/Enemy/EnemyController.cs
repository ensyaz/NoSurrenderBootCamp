using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float hitPoint;
    private EnemyPool enemyPool;
    private float currentHitPoint;
    private NavMeshAgent agent;

    [SerializeField] private float speed;


    private void Awake()
    {
        //enemyPool = GetComponentInParent<EnemyPool>();
        agent = GetComponentInParent<NavMeshAgent>();   
    }

    private void OnEnable()
    {
        currentHitPoint = hitPoint;
    }

    // Update is called once per frame
    void Update()
    {




    }









    public void GetHit(float takenDamage)
    {
        currentHitPoint -= takenDamage;
    }
}
