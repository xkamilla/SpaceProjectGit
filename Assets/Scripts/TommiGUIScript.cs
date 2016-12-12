using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TommiGUIScript : MonoBehaviour
{
	[SerializeField] Animator UIAnimator;

	public int score;
	public int SPCount;
	public int highscore;
	public Text scoreText;
	public Text spText;
	public Text highscoreText;

	public Image[] FullShields;


	void Start()
	{
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
		scoreText.text = score.ToString();
		spText.text = "SP: " + SPCount.ToString();
		highscoreText.text = "High Score: " + highscore.ToString ();
	}

    public void ShieldUpgradeBought(bool succeeded)
    {
		if (succeeded) {
			UIAnimator.Play ("ShieldBought");

		}
		else if (!succeeded) 
		{
			UIAnimator.Play ("ShieldDenied");
		}
    }
    public void SpeedUpgradeBought(bool succeeded)
    {
		if (succeeded) {
			UIAnimator.Play ("SpeedBought");

		} else if (!succeeded) {
			UIAnimator.Play ("SpeedDenied");
		}
    }
    public void StrengthUpgradeBought(bool succeeded)
    {
		if (succeeded) {
			UIAnimator.Play ("GunBought");

		} else if (!succeeded) {
			UIAnimator.Play ("GunDenied");
		}
    }
    public void CapacityUpgradeBought(bool succeeded)
    {
		if (succeeded) {
			UIAnimator.Play ("CapBought");

		} else if (!succeeded) {
			UIAnimator.Play ("CapDenied");
		}
    }

	public void UpdateUIScore(int score)
	{
		scoreText.text = score.ToString();
	}

	public void UpdateUISP(int sp)
	{
		spText.text = "SP: " + sp.ToString();
	}

	public void ShieldCheck(int shield)
	{
		//if shieldi on 0
		if (shield == 0)
		{
			FullShields [0].enabled = false;
			FullShields [1].enabled = false;
			FullShields [2].enabled = false;
			FullShields [3].enabled = false;
		}
		//else if shield on 1
		else if (shield == 1)
		{
			FullShields [0].enabled = true;
			FullShields [1].enabled = false;
			FullShields [2].enabled = false;
			FullShields [3].enabled = false;
		}
		//else if shieldi onki 2
		else if (shield == 2)
		{
			FullShields [0].enabled = true;
			FullShields [1].enabled = true;
			FullShields [2].enabled = false;
			FullShields [3].enabled = false;
		}
		//else if shieldi onki 3
		else if (shield == 3)
		{
			FullShields [0].enabled = true;
			FullShields [1].enabled = true;
			FullShields [2].enabled = true;
			FullShields [3].enabled = false;
		}
		//else if shieldi onki 4
		else if (shield == 4)
		{
			FullShields [0].enabled = true;
			FullShields [1].enabled = true;
			FullShields [2].enabled = true;
			FullShields [3].enabled = true;
		}
	}
	public void UpdateHighScore()
	{
		highscoreText.text = "High Score: " + PlayerPrefs.GetInt("High Score");
	}
}
