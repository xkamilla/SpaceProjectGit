using UnityEngine;
using System.Collections;

public class EnemyProjectileScript : MonoBehaviour
{
    public float speed;

    void Awake()
    {
    }

    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }
}
