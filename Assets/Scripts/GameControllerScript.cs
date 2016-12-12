using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    float randomValue;

    public int score;
    public int SPCount;

    public int highScore;
    string highScoreKey = "High Score";

    public GameObject PlayerPF;

    public float MissileDropChance;
    public float SBoosterDropChance;
    public float InvincibilityDropChance;
    public float SDestroyerDropChance;

    public GameObject MissilePrefab;
    public GameObject SBoosterPrefab;
    public GameObject InvincibilityPrefab;
    public GameObject SDestroyerPrefab;

    public GameObject BossHandler;

    public bool includeBoss;

    GameObject PlayerController;
    PlayerControllerScript PlayerCScript;

    GameObject UIObject;
    TommiGUIScript TGScript;

    EnemySpawnScript ESScript;

    int price;

    public bool spawnEnemies;

    bool boss;
    bool gameOver = false;
    int level;

    void Awake()
    {
        Time.timeScale = 1.0f;

        score = 0;
        SPCount = 0;

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);

        PlayerController = Instantiate(PlayerPF, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

        PlayerCScript = PlayerController.GetComponent<PlayerControllerScript>();

        UIObject = GameObject.Find("UI");
        TGScript = UIObject.GetComponent<TommiGUIScript>();

        ESScript = gameObject.GetComponent<EnemySpawnScript>();

        level = 1;
    }
    void Start()
    {
        TGScript.UpdateHighScore();
    }

    void Update()
    {
        if (gameOver)
        {
            //Gameover teksti
            if (Input.GetButton("Respawn"))
            {
                score = 0;
                SPCount = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                Instantiate(PlayerPF, new Vector3(0,0,0), Quaternion.identity);
                TGScript.UpdateUIScore(score);
                TGScript.UpdateUISP(SPCount);
            }
        }
    }
    public void GameOver()
    {
        Debug.Log("Press R to respawn");
        Debug.Log("Game Over");

        spawnEnemies = false;
        Time.timeScale = 0.3f;

        Debug.Log("Previous high score: " + PlayerPrefs.GetInt(highScoreKey, 0));
        Debug.Log("Current score: " + score);
        if (score > PlayerPrefs.GetInt(highScoreKey))
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
            Debug.Log("New highscore! " + PlayerPrefs.GetInt(highScoreKey));
            TGScript.UpdateHighScore();
        }
        gameOver = true;

    }
    public void UpdateScore(int points)
    {
        score += points;
        TGScript.UpdateUIScore(score);
    }
    public void UpdateSP(int parts)
    {
        SPCount += parts;
        TGScript.UpdateUISP(SPCount);
    }
    public void DropItem(Vector3 position)
    {
        randomValue = Random.Range(0.0f, 1.0f);
        GameObject PickUp;
        if (randomValue < SDestroyerDropChance)
        {
            PickUp = Instantiate(SDestroyerPrefab, position, Quaternion.identity) as GameObject;
            PickUp.name = "StarDestroyerPF";
        }
        else if (randomValue < InvincibilityDropChance)
        {
            PickUp = Instantiate(InvincibilityPrefab, position, Quaternion.identity) as GameObject;
            PickUp.name = "InvicibilityPF";
        }
        else if (randomValue < SBoosterDropChance)
        {
            PickUp = Instantiate(SBoosterPrefab, position, Quaternion.identity) as GameObject;
            PickUp.name = "SBoosterPF";
        }
        else if (randomValue < MissileDropChance && PlayerCScript.currentMissileCount < PlayerCScript.missileCount)
        {
            PickUp = Instantiate(MissilePrefab, position, Quaternion.identity) as GameObject;
            PickUp.name = "PickUpMissilePF";
        }
    }
    public bool BuyUpgrade(int id)
    {
        bool upgradeBought = false;
        switch (id)
        {
            case 1:
                price = 2;
                if (SPCount >= price)
                {
                    Debug.Log("You bought shield boost. SP: " + SPCount);
                    upgradeBought = true;
                    SPCount -= price;
                }
                TGScript.ShieldUpgradeBought(upgradeBought);
                break;
            case 2:
                price = 2;
                if (SPCount >= price)
                {
                    Debug.Log("You bought speed boost. SP: " + SPCount);
                    upgradeBought = true;
                    SPCount -= price;
                }
                TGScript.SpeedUpgradeBought(upgradeBought);
                break;
            case 3:
                price = 3;
                if (SPCount >= price)
                {
                    Debug.Log("You bought ion upgrades. SP: " + SPCount);
                    upgradeBought = true;
                    SPCount -= price;
                }
                TGScript.StrengthUpgradeBought(upgradeBought);
                break;
            case 4:
                price = 4;
                if (SPCount >= price)
                {
                    Debug.Log("You bought ion capacity upgrade. SP: " + SPCount);
                    upgradeBought = true;
                    SPCount -= price;
                }
                TGScript.CapacityUpgradeBought(upgradeBought);
                break;
            default:
                Debug.Log("You bought something that wasn't supposed to be bought");
                upgradeBought = false;
                break;
        }
        TGScript.UpdateUISP(SPCount);
        return upgradeBought;
    }
    public void ReachedGoal()
    {
        spawnEnemies = false;
        level++;
        if(level < 4)
        {
            StartCoroutine(NextLevelTransition());
        }
        else if(level == 4 && includeBoss)
        {
            Instantiate(BossHandler);
            Debug.Log("Bosu desu");
        }
    }

    IEnumerator NextLevelTransition()
    {
        Debug.Log("Starting next level...");
        yield return new WaitForSeconds(5.0f);
        Debug.Log("...now");
        SceneManager.LoadScene("Game" + level);
        spawnEnemies = true;
    }
}