using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject AsteroidPF;
    public GameObject SatellitePF;
    public GameObject Quick;
    public GameObject Slow;
    public GameObject Slower;

    GameObject enemy;
    float spawnTimer;
    public float nextEnemyBatchIn;
    int normalEnemyCount;

    public bool spawnEnemies;

    public float maxZRange;
    public float minZRange;

    Quaternion rotation;

    List<GameObject> EnemyList1 = new List<GameObject>();
    List<GameObject> EnemyList2 = new List<GameObject>();
    List<GameObject> EnemyList3 = new List<GameObject>();
    List<GameObject> EnemyList4 = new List<GameObject>();

    List<GameObject> enemyList;
    GameObject level;

    float checkpoint1;
    float checkpoint2;
    float checkpoint3;
    float checkpoint4;

    void Awake()
    {
        spawnTimer = 0;
        //normalEnemyCount = 1;

        PrepareSpawnList1();
        PrepareSpawnList2();
        PrepareSpawnList3();
        PrepareSpawnList4();

        level = GameObject.FindWithTag("BG");

        checkpoint1 = GameObject.Find("Checkpoint1").transform.position.x; //338;
        checkpoint2 = GameObject.Find("Checkpoint2").transform.position.x; //190;
        checkpoint3 = GameObject.Find("Checkpoint3").transform.position.x; //42;
        checkpoint4 = GameObject.Find("Checkpoint4").transform.position.x; //-106;

        Debug.Log(checkpoint1);
        Debug.Log(checkpoint2);
        Debug.Log(checkpoint3);
        Debug.Log(checkpoint4);
    }
    void Update()
    {
        if (spawnEnemies)
        {
            if (spawnTimer <= 0)
            {
                //NewEnemy();
                //spawnTimer = nextEnemyIn;
                if(level.transform.position.x > checkpoint1)
                {
                    enemyList = EnemyList1;
                    Debug.Log("1");
                }
                else if(level.transform.position.x <= checkpoint1 && level.transform.position.x > checkpoint2)
                {
                    enemyList = EnemyList2;
                    Debug.Log("2");
                }
                else if(level.transform.position.x <= checkpoint2 && level.transform.position.x > checkpoint3)
                {
                    enemyList = EnemyList3;
                    Debug.Log("3");
                }
                else if(level.transform.position.x <= checkpoint3 && level.transform.position.x > checkpoint4)
                {
                    enemyList = EnemyList4;
                    Debug.Log("4");
                }
                else if(level.transform.position.x <= checkpoint4)
                {
                    Debug.Log("Boss Area");
                    enemyList = EnemyList4;
                }
                else
                {
                    enemyList = EnemyList1;
                    Debug.Log("Error in enemy spawn");
                }

                StartCoroutine(WaitForEnemySpawn(enemyList));
                spawnTimer = nextEnemyBatchIn;
            }
            else
            {
                spawnTimer -= Time.deltaTime;
            }
        }
    }

    /*void NewEnemy()
    {
        if (normalEnemyCount == 1)
        {
            enemy = AsteroidPF;
            normalEnemyCount++;
            rotation = Quaternion.identity;
        }
        else if (normalEnemyCount == 2)
        {
            enemy = SatellitePF;
            normalEnemyCount++;
            rotation = Quaternion.identity;
        }
        else if (normalEnemyCount == 3)
        {
            enemy = Quick;
            normalEnemyCount++;
            rotation = Quaternion.Euler(-90, 0, 0);
        }
        else if (normalEnemyCount == 4)
        {
            enemy = Slow;
            normalEnemyCount++;
            rotation = Quaternion.Euler(-90, 0, 0);
        }
        else if (normalEnemyCount == 5)
        {
            enemy = Slower;
            normalEnemyCount = 1;
            rotation = Quaternion.Euler(-90, 0, 0);
        }

        Vector3 spawnPosition = new Vector3(33, 0, Random.Range(minZRange, maxZRange));
        Instantiate(enemy, spawnPosition, rotation);
    }*/

    void PrepareSpawnList1()
    {
        EnemyList1.Add(AsteroidPF);
        EnemyList1.Add(AsteroidPF);
        EnemyList1.Add(AsteroidPF);
        EnemyList1.Add(AsteroidPF);
        EnemyList1.Add(AsteroidPF);
    }
    void PrepareSpawnList2()
    {
        EnemyList2.Add(AsteroidPF);
        EnemyList2.Add(SatellitePF);
        EnemyList2.Add(Quick);
        EnemyList2.Add(SatellitePF);
        EnemyList2.Add(AsteroidPF);
    }
    void PrepareSpawnList3()
    {
        EnemyList3.Add(SatellitePF);
        EnemyList3.Add(Quick);
        EnemyList3.Add(SatellitePF);
        EnemyList3.Add(Quick);
    }
    void PrepareSpawnList4()
    {
        EnemyList4.Add(Quick);
        EnemyList4.Add(Quick);
        EnemyList4.Add(Slow);
        EnemyList4.Add(Slower);
    }

    IEnumerator WaitForEnemySpawn(List<GameObject> list)
    {
        foreach (GameObject obj in list)
        {
            yield return new WaitForSeconds(1.0f);
            if(obj.name == "Tiedustelualus")
            {
                rotation = Quaternion.Euler(90, 0, 0);
            }
            else if (obj.name == "RaskasTaistelualus" || obj.name == "RaskaampiTaistelualus")
            {
                rotation = Quaternion.Euler(90, 180, 0);
            }
            else
            {
                rotation = Quaternion.identity;
            }
            Instantiate(obj, new Vector3(Random.Range(30, 34), 0, Random.Range(minZRange, maxZRange)), rotation);
        }
    }
}
