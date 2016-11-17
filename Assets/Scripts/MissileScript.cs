using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour
{
    public float speed;
    public GameObject MissileExplosion;

    void Awake()
    {
    }

    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(MissileExplosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
