using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject ShootingEnemyPrefab;
    GameObject enemy;
    float spawnTimer;
    public float nextEnemyIn;
    int normalEnemyCount;

    void Awake()
    {
        spawnTimer = nextEnemyIn;
        normalEnemyCount = 0;
    }
    void Update()
    {
        if (spawnTimer <= 0)
        {
            NewEnemy();
            spawnTimer = nextEnemyIn;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    void NewEnemy()
    {
        if(normalEnemyCount < 3)
        {
            enemy = EnemyPrefab;
            normalEnemyCount++;
        }
        else
        {
            enemy = ShootingEnemyPrefab;
            normalEnemyCount = 0;
        }
        Vector3 spawnPosition = new Vector3(33, 0, Random.Range(-9, 9));
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
