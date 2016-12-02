using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour
{
    public float speed;
    public GameObject MissileExplosion;
    //public GameObject LaserPF;

    GameObject Explosion;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            ProjectileExplosion();
        }
    }

    public void ProjectileExplosion()
    {
        Instantiate(MissileExplosion, transform.position, Quaternion.identity);

        Explosion = Instantiate(MissileExplosion, transform.position, Quaternion.identity) as GameObject;
        Explosion.transform.localScale = Vector3.Scale(Explosion.transform.localScale, transform.localScale);

        Destroy(gameObject);
    }
}
