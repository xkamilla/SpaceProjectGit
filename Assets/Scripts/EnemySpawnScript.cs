using UnityEngine;
using System.Collections;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    float spawnTimer;
    public float nextEnemyIn;

    void Awake()
    {
        spawnTimer = nextEnemyIn;
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
        Vector3 spawnPosition = new Vector3(33, 0, Random.Range(-9, 9));
        Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
    }
}
