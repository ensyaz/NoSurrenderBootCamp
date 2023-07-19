using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float disableTime;

    private WaitForSeconds disableTimer;

    private void Awake()
    {
        disableTimer = new WaitForSeconds(disableTime);
    }

    private void OnEnable()
    {
        StartCoroutine(DisableBullet());
    }
    // Disable bullet after its fired up within disableTime second
    private IEnumerator DisableBullet()
    {
        yield return disableTimer;
        Destroy(gameObject);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().GetHit(damage);
            Destroy(gameObject);
        }
            
    }
}
