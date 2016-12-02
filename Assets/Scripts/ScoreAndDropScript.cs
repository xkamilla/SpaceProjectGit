using UnityEngine;
using System.Collections;

public class ScoreAndDropScript : MonoBehaviour
{
    GameObject GameController;
    GameControllerScript GCScript;

    float randomValue;
    public float dropChance;

    public int score;
    public int parts;

    void Awake()
    {
        GameController = GameObject.Find("GameController");
        GCScript = GameController.GetComponent<GameControllerScript>();

    }

    public void GiveScoreAndSP()
    {
        GCScript.UpdateScore(score);
        GCScript.UpdateSP(parts);
        randomValue = Random.Range(0.0f, 1.0f);
        if (randomValue <= dropChance)
        {
            GCScript.DropItem(transform.position);
        }
        Destroy(gameObject);
    }
}
