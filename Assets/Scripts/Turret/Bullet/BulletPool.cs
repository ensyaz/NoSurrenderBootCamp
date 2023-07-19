using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject[] bulletObjects;
    public int disabledBulletCount;

    [Header("Attributes")]
    [SerializeField] private int bulletAmount;

    [Header("Components")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform muzzleTransform;

    private void Awake()
    {
        bulletObjects = new GameObject[bulletAmount];

        InitBullets();
    }

    private void InitBullets()
    {
        for (int i = 0; i < bulletAmount; i++)
        {
            bulletObjects[i] = Instantiate(bulletPrefab, muzzleTransform, false);
            bulletObjects[i].name = "Bullet " + (i+1).ToString();
            bulletObjects[i].SetActive(false);
        }
    }
}
