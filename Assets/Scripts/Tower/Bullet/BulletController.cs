using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float disableTime;

    private Rigidbody rb;
    private SphereCollider sphereCollider;
    private Vector3 colliderOffset;
    private GameObject targetObject;
    private bool isFollow;

    private WaitForSeconds disableTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        disableTimer = new WaitForSeconds(disableTime);

        colliderOffset = new Vector3(0,0, transform.localScale.z / 2);
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
    }

    private void Update()
    {
        if (isFollow)
        {
            if (!targetObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
            }

            else if (Vector3.Distance(transform.position, targetObject.transform.position) < 0.5f)
            {
                targetObject.GetComponent<AIController>().GetDamage(damage);
                isFollow = false;
                targetObject = null;
                gameObject.SetActive(false);
            }
        }
    }

    public void BulletCheckPosition(GameObject _targetObject)
    {
        targetObject = _targetObject;
        isFollow = true;
    }

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
