using System.Collections;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public int disabledEnemyCount;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private int enemyAmount;

    private GameObject[] enemyObjects;

    private void Awake()
    {
        enemyObjects = new GameObject[enemyAmount];
        InitEnemy();
        StartCoroutine(SetEnemy());
    }

    private void InitEnemy()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            enemyObjects[i] = Instantiate(enemyPrefab, transform);
            enemyObjects[i].name = "Enemy " + (i + 1).ToString();
            enemyObjects[i].SetActive(false);
            enemyObjects[i].transform.position = new Vector3(Random.Range(-5f, 5f), enemyObjects[i].transform.position.y, 14f);
        }
    }

    private IEnumerator SetEnemy()
    {
        int cnt = 0;

        while (cnt < enemyObjects.Length)
        {
            yield return new WaitForSeconds(1f);
            enemyObjects[cnt].SetActive(true);
            cnt++;
        }
    }
}
