using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour
{
    public float speed;

    void Awake()
    {
    }

    void Update()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
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
