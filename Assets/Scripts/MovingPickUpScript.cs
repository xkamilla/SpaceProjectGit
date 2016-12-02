using UnityEngine;
using System.Collections;

public class MovingPickUpScript : MonoBehaviour
{
    public float movingSpeed;
    public float rotatingSpeed;

    void Update()
    {
        transform.position += new Vector3(-1.0f, 0.0f, 0.0f) * movingSpeed * Time.deltaTime;

        transform.Rotate(rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime, rotatingSpeed * Time.deltaTime);
    }
}
