using UnityEngine;
using System.Collections;

public class Lifetime : MonoBehaviour 
{
	public float time = 5;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, time);
	}
}
