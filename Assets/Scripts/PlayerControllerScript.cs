using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour
{
    public float xMin, xMax, zMin, zMax;

    public float playerSpeed;
    float maxPlayerSpeed;

    public float currentPlayerShield;
    public int playerShield;
    int maxPlayerShield;

    bool chargeShield;
    float rechargeTime;
    float shieldTimer;

    public int strengthLevel;
    Vector3 scale;
    int maxStrengthLevel;

    public float fireRate;
    float maxFireRate;

    public int currentMissileCount;
    public int missileCount;
    int maxMissileCount;

    float boosterTimer;
    bool booster;

    int shieldInt;

    public GameObject Projectile;
    public GameObject Missile;
    public GameObject ExplosionHandler;

    GameObject Explosion;

    GameObject GameController;
    GameControllerScript GControllerScript;

    GameObject TGSObject;
    TommiGUIScript TGScript;

    public GameObject LaserHandler;

    int chosenUpgradeId;

    float timer = 0.0f;
    float upgradeTimer = 0.0f;
    bool upgradeTimerRunning; 

    void Awake()
    {
        GameController = GameObject.Find("GameController");
        GControllerScript = GameController.GetComponent<GameControllerScript>();

        //TGSObject = GameObject.Find("UI");
        //TGScript = TGSObject.GetComponent<TommiGUIScript>();

        //playerShield = 0;
        currentPlayerShield = playerShield;
        //shieldInt = currentPlayerShield
        maxPlayerSpeed = 35.0f;
        maxPlayerShield = 4;
        chargeShield = true;
        shieldTimer = 0.0f;
        rechargeTime = 0.2f;

        strengthLevel = 0;
        scale = new Vector3(0.7f, 0.7f, 0.7f);
        maxStrengthLevel = 4;
        //fireRate = 0.6f;
        maxFireRate = 0.1f;

        //missileCount = 0;
        currentMissileCount = missileCount;
        maxMissileCount = 8;

        boosterTimer = 0.0f;
        booster = false;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonUp("Fire1") && timer >= fireRate)
        {
            Instantiate(LaserHandler, transform.position + new Vector3(0.694f, 0.0f, -0.305f), Quaternion.identity);
            timer = 0.0f;
        }

        if (Input.GetButton("Fire2") && timer >= fireRate && currentMissileCount != 0)
        {
            Explosion = Instantiate(Missile, transform.position + new Vector3(0.694f, 0.0f, -0.305f), Quaternion.identity) as GameObject;
            Explosion.transform.localScale = scale;

            currentMissileCount--;
            timer = 0.0f;
        }
        
        if(upgradeTimerRunning)
        {
            upgradeTimer -= Time.deltaTime;
        }
        if (upgradeTimer <= 0)
        {
            upgradeTimerRunning = false;

            if (Input.GetButtonUp("Upgrade1"))
            {
                if (playerShield < maxPlayerShield)
                {
                    chosenUpgradeId = 1;
                    bool approved = GControllerScript.BuyUpgrade(chosenUpgradeId);
                    Debug.Log(approved);
                    if (approved)
                    {
                        playerShield++;
                        Debug.Log("Max Shield: " + playerShield);
                    }
                }
                else
                {
                    Debug.Log("You have reached maximum");
                }
            }
            else if (Input.GetButtonUp("Upgrade2"))
            {
                if (playerSpeed < maxPlayerSpeed)
                {
                    chosenUpgradeId = 2;
                    bool approved = GControllerScript.BuyUpgrade(chosenUpgradeId);
                    Debug.Log(approved);
                    if (approved)
                    {
                        playerSpeed += 4.0f;
                        Debug.Log("Speed: " + playerSpeed);
                    }
                }
                else
                {
                    Debug.Log("You have reached maximum");
                }
            }
            else if (Input.GetButtonUp("Upgrade3"))
            {
                if (strengthLevel < maxStrengthLevel)
                {
                    chosenUpgradeId = 3;
                    bool approved = GControllerScript.BuyUpgrade(chosenUpgradeId);
                    if (approved)
                    {
                        strengthLevel++;
                        scale += new Vector3(0.3f, 0.3f, 0.3f);
                        fireRate -= 0.1f;
                    }
                }
                else
                {
                    Debug.Log("You have reached maximum");
                }
            }
            else if (Input.GetButtonUp("Upgrade4"))
            {
                if (missileCount < maxMissileCount)
                {
                    chosenUpgradeId = 4;
                    bool approved = GControllerScript.BuyUpgrade(chosenUpgradeId);
                    if (approved)
                    {
                        missileCount++;
                    }
                }
                else
                {
                    Debug.Log("You have reached maximum");
                }
            }
        }
    }

    void FixedUpdate()
    {
        //Debug.Log("Shield is: " + currentPlayerShield + " from " + playerShield);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        transform.Translate(new Vector3(movement.x * Time.deltaTime * playerSpeed, movement.y * Time.deltaTime * playerSpeed, movement.z * Time.deltaTime * playerSpeed));

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(transform.position.z, zMin, zMax)
        );

        if (currentPlayerShield < playerShield)
        {
            RechargeShield();
        }
        if (booster)
        {
            ShieldRechargeBoost();
        }


        CheckShieldInt();
        //TGScript.ShieldCheck(shieldInt);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyProjectile")
        {
            shieldTimer = 0.0f;
            currentPlayerShield = Mathf.Floor(currentPlayerShield) - 1;

            if (currentPlayerShield < 0)
            {
                PlayerDies();
            }
            Destroy(other.gameObject);
        }
        else if(other.tag == "Terrain")
        {
            PlayerDies();
        }
        else if (other.tag == "PickUp")
        {
            switch (other.name)
            {
                case "PickUpMissilePF":
                    Debug.Log("Missile+");
                    if (currentMissileCount < missileCount)
                    {
                        currentMissileCount++;
                        Destroy(other.gameObject);
                    }
                    break;
                case "SBoosterPF":
                    Debug.Log("Shield Booster");
                    rechargeTime = rechargeTime + 0.5f;
                    booster = true;
                    Destroy(other.gameObject);
                    break;
                case "InvicibilityPF":
                    Debug.Log("Invicible");
                    Destroy(other.gameObject);
                    break;
                case "StarDestroyerPF":
                    Debug.Log("StarDestroyer");
                    Destroy(other.gameObject);
                    break;
                default:
                    Debug.Log("wtf. It seems to be a " + other.name);
                    break;
            }
        }
    }
    void RechargeShield()
    {
        shieldTimer += Time.deltaTime;

        if (shieldTimer >= 3.0f)
        {
            currentPlayerShield += Time.deltaTime * rechargeTime;

            if (currentPlayerShield >= playerShield)
            {
                currentPlayerShield = (int)currentPlayerShield;
                shieldTimer = 0.0f;
            }
        }
    }
    void ShieldRechargeBoost()
    {
        boosterTimer += Time.deltaTime;

        if (boosterTimer >= 10.0f)
        {
            booster = false;
            rechargeTime = 0.2f;
        }
    }

    void CheckShieldInt()
    {
        shieldInt = (int)Mathf.Floor(currentPlayerShield);
    }

    void PlayerDies()
    {
        Instantiate(ExplosionHandler, transform.position, Quaternion.identity);
        GControllerScript.GameOver();
        Destroy(gameObject);
    }
}