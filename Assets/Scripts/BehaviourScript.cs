using UnityEngine;
using System.Collections;

public class BehaviourScript : MonoBehaviour
{
    //float xMin, xMax, zMin, zMax;

    /*public float movingSpeed;
    public float nextTurnIn;
    public float rotatingSpeed;*/

    /*float randomValue;
    float numberTimer;*/

    public int health;

    public GameObject ExplosionHandler;
    ScoreAndDropScript ScoreDropScript;

    GameObject UIObject;
    TommiGUIScript TGScript;

    //GameObject playerObject;
    //PlayerControllerScript PlayerController;

    void Awake()
    {
        ScoreDropScript = GetComponent<ScoreAndDropScript>();

        //UIObject = GameObject.Find("UI");
        //TGScript = UIObject.GetComponent<TommiGUIScript>();

        //playerObject = GameObject.FindWithTag("Player");
        //PlayerController = playerObject.GetComponent<PlayerControllerScript>();

        /*randomValue = Random.Range(-0.4f, 0.4f);
        numberTimer = nextTurnIn;*/

        /*xMin = -15.0f;
        xMax = 40.0f;
        zMin = -9.5f;
        zMax = 9.0f;*/
    }

    /*void Update()
    {
        transform.position += new Vector3(-1.0f, 0.0f, randomValue) * movingSpeed * Time.deltaTime;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(transform.position.z, zMin, zMax)
        );

        transform.Rotate(rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime);

        if (numberTimer <= 0)
        {
            randomValue = Random.Range(-0.4f, 0.4f);
            numberTimer = nextTurnIn;
        }
        else
        {
            numberTimer -= Time.deltaTime;
        }
    }*/

    public void DamageTaken(bool instaDeath)
    {
        if (!instaDeath)
        {
            health -= 1;
            if (health <= 0)
            {
                ScoreDropScript.GiveScoreAndSP();

                //TGScript.Räjähdys(transform.position);

                Instantiate(ExplosionHandler, transform.position, Quaternion.identity);
            }
        }
        else
        {
            ScoreDropScript.GiveScoreAndSP();
            Instantiate(ExplosionHandler, transform.position, Quaternion.identity);
        }
    }
}