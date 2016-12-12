using UnityEngine;
using System.Collections;

public class BossHandlerScript : MonoBehaviour
{
    bool bossCreated;

    public GameObject bossPF;
    Vector3 spawnPosition = new Vector3(40, 0, 0);

    void Awake()
    {
        bossCreated = false;
    }

    void Update()
    {
        if(!bossCreated && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Instantiate(bossPF, spawnPosition, Quaternion.Euler(0, 0, 90));
            bossCreated = true;
        }
    }
}
