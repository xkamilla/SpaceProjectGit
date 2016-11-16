using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        
    }
}