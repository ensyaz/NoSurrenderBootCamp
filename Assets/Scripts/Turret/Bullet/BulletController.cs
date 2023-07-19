using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float disableTime;

    private Rigidbody rb;

    private WaitForSeconds disableTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
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
        gameObject.SetActive(false);
        //Destroy(gameObject);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().GetHit(damage);
            //Destroy(gameObject);
            gameObject.SetActive(false);
        } 
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
