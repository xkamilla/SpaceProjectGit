using UnityEngine;
using System.Collections;

public class EnemyShootingScript : MonoBehaviour {

    public GameObject bulletPrefab;
	public float nextShotIn;
    float shotTimer;

	void Update ()
    {
	    if(shotTimer <= 0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            shotTimer = nextShotIn;
        }
        else
        {
            shotTimer -= Time.deltaTime;
        }
	}
}
