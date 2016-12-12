using UnityEngine;
using System.Collections;

public class scaleAssbindingofIsaac : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale += new Vector3 (Random.Range (0.0f, 2.0f), Random.Range (0.0f, 2.0f), Random.Range (0.0f, 2.0f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
