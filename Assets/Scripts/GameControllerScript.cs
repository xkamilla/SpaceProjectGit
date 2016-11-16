using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour
{
    bool gameOver;

    void Awake()
    {
        gameOver = false;
    }
	
	void Update ()
    {
	    
	}

    void GameOver()
    {
        Debug.Log("Game Over");
    }
}
