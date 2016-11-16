using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour
{

    public float speed;
    float randomValue;
    float numberTimer;
    float nextTurnIn;

    void Awake()
    {
        randomValue = Random.Range(-0.4f, 0.4f);
        nextTurnIn = 2.0f;
        numberTimer = nextTurnIn;
    }

	void Update ()
    {
        transform.position += new Vector3(-1.0f, 0.0f, randomValue) * speed * Time.deltaTime;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -10, 40),
            0.0f,
            Mathf.Clamp(transform.position.z, -9, 9)
        );

        transform.Rotate(20 * Time.deltaTime, 20 * Time.deltaTime, 0);

        if(numberTimer <= 0)
        {
            randomValue = Random.Range(-0.4f, 0.4f);
            numberTimer = nextTurnIn;
        }
        else
        {
            numberTimer -= Time.deltaTime;
        }
	}
}
