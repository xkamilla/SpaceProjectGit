using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour {

    float randomValue;
    float numberTimer;
    float nextTurnIn;

    void Awake()
    {
        randomValue = 0.0f;
        nextTurnIn = 2.0f;
        numberTimer = nextTurnIn;
    }

	void Update ()
    {
        transform.position += new Vector3(-1.0f, 0.0f, randomValue) * Time.deltaTime;
        if(numberTimer <= 0)
        {
            randomValue = Random.Range(-0.7f, 0.7f);
            numberTimer = nextTurnIn;
        }
        else
        {
            numberTimer -= Time.deltaTime;
        }
	}
}
