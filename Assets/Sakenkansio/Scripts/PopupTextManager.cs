using UnityEngine;
using System.Collections;

public class PopupTextManager : MonoBehaviour {

	private static PopupTextManager instance;

	public GameObject textPrefab;
	GameObject playerparent;

	void Start ()
	{
		playerparent = GameObject.FindWithTag ("Player");
	}

	public static PopupTextManager Instance


	{
		get
		{
			if (instance == null) 
			{
				instance = GameObject.FindObjectOfType<PopupTextManager> ();
			}
			return instance;
		}
	}

	public void CreateText(Vector3 position)
	{
		GameObject sct = (GameObject)Instantiate (textPrefab, position, Quaternion.identity);
		sct.transform.SetParent (playerparent.transform);
		sct.GetComponent<Transform> ().Rotate (180, 0, 180);
	}


}
