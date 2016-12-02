using UnityEngine;
using System.Collections;

public class ExplodingMissileScript : MonoBehaviour
{
    float timer;

    void Awake()
    {
        timer = 1.5f;
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        { 
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Projectile")
        {
            BehaviourScript BScript = other.GetComponent<BehaviourScript>();
            if (BScript != null)
            {
                BScript.DamageTaken(true);
            }
        }
    }
}
