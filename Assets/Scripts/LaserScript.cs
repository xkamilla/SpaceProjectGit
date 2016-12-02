using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
    //Alkuperäinen laseri

    /*bool durationCountdown = false;
    public float laserDuration = 0.5f; 
    float range = 40.0f;
    float timer = 0.0f;

    Ray shootRay;
    RaycastHit shootHit;
    LineRenderer gunLine;

    bool shot = false;

    void Awake()
    {
        gunLine = GetComponent<LineRenderer>();
    }

    public void Update()
    {
        timer += Time.deltaTime;

        if (!shot)
        {
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            shootRay.origin = transform.position;
            shootRay.direction = transform.right;

            if (Physics.SphereCast(shootRay, 1.5f, out shootHit, range))
            {
                BehaviourScript behaviourScript = shootHit.collider.GetComponent<BehaviourScript>();
                if (behaviourScript != null && shootHit.transform.tag == "Enemy")
                {
                    behaviourScript.DamageTaken();
                }
                else if(shootHit.transform.tag == "Projectile")
                {
                    
                }
                gunLine.SetPosition(1, new Vector3(shootHit.point.x, 0.0f, transform.position.z));
            }
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
            durationCountdown = true;
            shot = true;
        }

        if (durationCountdown && timer >= laserDuration)
        {
            Destroy(gameObject);
        }
    }*/
}
