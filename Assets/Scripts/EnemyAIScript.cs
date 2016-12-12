using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour
{
    public enum shootingType
    {
        straight,
        fan,
        atPlayer
    }

    float xMin, xMax, zMin, zMax;

    public bool shoots;
    public bool shootsMissiles;
    bool missilesNow;
    bool versatileMoving;
    public bool rotating;
    public float rotatingSpeed;
    public float speed;

    public float timeBetweenBullets;
    public float shootCoolDown;
    public int howManyShots;

    public shootingType shootPattern;

    float randomValue;
    float numberTimer;
    bool timerRunning;

    public GameObject BulletPrefab;
    public GameObject MissilePrefab;
    Quaternion bulletRotation;
    GameObject bullet;

    int i = 0;

    void Awake()
    {
        randomValue = Random.Range(-0.2f, 0.2f);
        timerRunning = true;

        missilesNow = false;

        xMin = -15.0f;
        xMax = 40.0f;
        zMin = -9.0f;
        zMax = 9.0f;

        numberTimer = shootCoolDown / 2;
    }
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(transform.position.z, zMin, zMax)
        );

        if (!versatileMoving)
        {
            transform.position += new Vector3(-1.0f, 0.0f, randomValue) * speed * Time.deltaTime;
        }
        else
        {
            //Superimpi liikkuminen
        }

        if(rotating)
        {
            transform.Rotate(rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime);
        }

        if (shoots)
        {
            if (timerRunning)
            {
                numberTimer += Time.deltaTime;
            }

            if (numberTimer >= shootCoolDown)
            {
                timerRunning = false;
                numberTimer = 0.0f;
                StartCoroutine(WaitBullets());
            }
        }
    }

    IEnumerator WaitBullets()
    {
        while (i != howManyShots)
        {
            yield return new WaitForSeconds(timeBetweenBullets);


            if(shootPattern == shootingType.straight)
            {
                bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
                bullet.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else if (shootPattern == shootingType.atPlayer)
            {
                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
                    bullet.transform.LookAt(player.transform);
                }
            }
            else if (shootPattern == shootingType.fan)
            {
                for (int j = 1; j <= 4; j++)
                {
                    bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
                    bullet.transform.rotation = Quaternion.Euler(0, -30 + (-100 / 4 * j), 0);
                }
            }

            i++;
        }
        i = 0;

        if (shootsMissiles)
        {
            yield return new WaitForSeconds(3);

            Instantiate(MissilePrefab, transform.position, Quaternion.Euler(0, -90, 0));
        }
        timerRunning = true;
    }

    void OnTriggerEnter(Collider other)
    {
        /*if(other.tag == "Hazard")
        {
            randomValue = Random.Range(0.2f, 0.7f);
        }*/
    }
}
