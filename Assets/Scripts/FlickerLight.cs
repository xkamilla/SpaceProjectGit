using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour {

	public GameObject Lights;
	public float timer;

	public float minFlick;
	public float maxFlick;

	void Start()
	{
		StartCoroutine (FlickeringLight ());
	}

	IEnumerator FlickeringLight()
	{
		Lights.SetActive(true);
		timer = Random.Range(minFlick, maxFlick);
		yield return new WaitForSeconds(timer);
		Lights.SetActive(false);
		timer = Random.Range (minFlick, maxFlick);
		yield return new WaitForSeconds (timer);
		StartCoroutine(FlickeringLight());
	}
}
