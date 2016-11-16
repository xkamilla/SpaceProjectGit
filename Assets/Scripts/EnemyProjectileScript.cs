using UnityEngine;
using System.Collections;

public class EnemyProjectileScript : MonoBehaviour
{
    float speed;

    void Awake()
    {
        speed = 15.0f;
    }

    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }
}
