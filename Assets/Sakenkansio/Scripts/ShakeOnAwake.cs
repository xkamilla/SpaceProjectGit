using UnityEngine;
using System.Collections;

public class ShakeOnAwake : MonoBehaviour 
{
	public float amplitude = 0.1f;
	public float duration = 0.5f;

	// Use this for initialization
	void Start () 
	{
		CamShake.Instance.Shake (amplitude, duration);
	}
}
