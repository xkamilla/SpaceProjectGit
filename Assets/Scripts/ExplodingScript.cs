using UnityEngine;
using System.Collections;

public class ExplodingScript : MonoBehaviour
{
    float timer;
    bool exploded;

    public GameObject ExplosionPrefab;
    GameObject Explosion;

    void Awake()
    {
        exploded = false;
        timer = 1.0f;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer >= 0)
        {
            if (!exploded)
            {
                Explosion = Instantiate(ExplosionPrefab, transform.position, Quaternion.identity) as GameObject;
                exploded = true;
            }
        }
        else
        {
            Destroy(Explosion);
            Destroy(gameObject);
        }
    }
}
