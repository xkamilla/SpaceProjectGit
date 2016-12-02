using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    //public float speed;
    public GameObject ExplosionHandler;



    void Update()
    {
        //transform.position += -transform.right * speed * Time.deltaTime;
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(ExplosionHandler, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.name == "ProjectileBarrier")
        {
            Destroy(gameObject);
        }
    }*/
}