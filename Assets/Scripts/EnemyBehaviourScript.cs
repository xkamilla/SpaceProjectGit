using UnityEngine;
using System.Collections;

public class EnemyBehaviourScript : MonoBehaviour
{

    public float speed;
    float randomValue;
    float randomValue2;
    float numberTimer;
    float nextTurnIn;
    GameObject GameController;
    GameControllerScript GCScript;

    void Awake()
    {
        randomValue = Random.Range(-0.4f, 0.4f);
        nextTurnIn = 2.0f;
        numberTimer = nextTurnIn;

        GameController = GameObject.Find("GameController");
        GCScript = GameController.GetComponent<GameControllerScript>();
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
    void OnDestroy()
    {
        randomValue2 = Random.Range(0.0f,1.0f);
        Debug.Log(randomValue2);
        if (randomValue2 <= 0.2f)
        {
            GCScript.DropItem(transform.position);
        }
    }
}
