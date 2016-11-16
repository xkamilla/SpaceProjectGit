using UnityEngine;
using System.Collections;

public class BoundaryScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
	}
}
