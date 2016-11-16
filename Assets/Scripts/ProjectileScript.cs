using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    float speed;

    void Awake()
    {
        speed = 15.0f;
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}