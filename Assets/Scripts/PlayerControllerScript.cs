using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour
{
    public float speed;
    public float xMin, xMax, zMin, zMax;

    private float nextFire;
    public float fireRate;

    public GameObject Projectile;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Projectile, transform.position, Quaternion.identity);
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
        if (other.tag != "Projectile")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
