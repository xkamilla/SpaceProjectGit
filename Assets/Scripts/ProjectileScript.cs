using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour
{
    public float speed;
    GameObject GameController;
    GameControllerScript GCScript;

    void Awake()
    {
        GameController = GameObject.Find("GameController");
        GCScript = GameController.GetComponent<GameControllerScript>();
    }

    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GCScript.UpdateScore(20);
            GCScript.UpdateSP(1);

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.name == "ProjectileBarrier")
        {
            Destroy(gameObject);
        }
    }
}