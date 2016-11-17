using UnityEngine;
using System.Collections;

public class MissileExplodingScript : MonoBehaviour
{
    public float timer;
    bool exploded;
    public GameObject ExplosionPrefab;
    GameObject Explosion;

    void Awake()
    {
        exploded = false;
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

	void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Projectile")
        {
            Destroy(other.gameObject);
        }
	}
}
