using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour
{
    public float speed;
    Vector3 startPosition;

    void Awake()
    {
        startPosition = new Vector3(1235.1f, 34.5f, -15.2f);
    }

    void Update()
    {
        /*if (transform.position.x <= -297.7)
        {
            transform.position = startPosition;
            if (gameObject.tag == "BG")
            {
                turnsB4Level++;
                Debug.Log(turnsB4Level);
            }
        }
        else
        {*/
            transform.position += -Camera.main.transform.right * speed * Time.deltaTime;
        //}
    }
}
