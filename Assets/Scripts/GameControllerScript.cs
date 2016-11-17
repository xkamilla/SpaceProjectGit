using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour
{
    bool gameOver;
    static GameObject[] SPList;
    int numberSpawned;
    int randomValue;

    public int score;
    public int SPCount;

    GameObject PlayerController;
    PlayerControllerScript PlayerCScript;

    /// HUOMIO! Pelaajan shield löytyy PlayerController Scriptistä
    /// Sen arvon saa kirjoittamalla:
    /// PlayerCScript.playerShield;

    void Awake()
    {
        gameOver = false;
        SPList = Resources.LoadAll<GameObject>("ShipParts");
        numberSpawned = 0;
        score = 0;
        SPCount = 0;

        PlayerController = GameObject.Find("PlayerPrefab");
        PlayerCScript = PlayerController.GetComponent<PlayerControllerScript>();
    }
    void GameOver()
    {
        Debug.Log("Game Over");
    }
    public void UpdateScore(int points)
    {
        score += points;
    }
    public void UpdateSP(int parts)
    {
        SPCount += parts;
    }
    public void DropItem(Vector3 position)
    {
        randomValue = Random.Range(0, SPList.Length);
        Instantiate(SPList[randomValue], position, Quaternion.identity);
    }
}
