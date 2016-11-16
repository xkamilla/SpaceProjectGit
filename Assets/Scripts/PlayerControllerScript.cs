using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour
{
    public float speed;
    public float xMin, xMax, zMin, zMax;

    private float nextFire;
    public float fireRate;

    int missileCount;
    Quaternion missileRotation;

    public GameObject Projectile;
    public GameObject Missile;

    public GameObject explosion;

    void Awake()
    {
        missileCount = 3;
        missileRotation = Quaternion.Euler(0, 0, 90);
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Projectile, transform.position, Quaternion.identity);
        }
        if (Input.GetButton("Fire2") && Time.time > nextFire && missileCount != 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Missile, transform.position, missileRotation);
            missileCount--;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(new Vector3(movement.x * Time.deltaTime * speed, movement.y * Time.deltaTime * speed, movement.z * Time.deltaTime * speed));

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(transform.position.z, zMin, zMax)
        );
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Enemy_Projectile")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
