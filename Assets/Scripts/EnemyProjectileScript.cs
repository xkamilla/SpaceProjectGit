using UnityEngine;
using System.Collections;

public class EnemyProjectileScript : MonoBehaviour
{
    public float speed;

    void Awake()
    {
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hazard")
        {
            Destroy(gameObject);
        }
    }
}
