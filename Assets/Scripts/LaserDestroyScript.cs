using UnityEngine;
using System.Collections;
using System.Linq;

public class LaserDestroyScript : MonoBehaviour
{
    EffectSettings eSettings;

    GameObject UIObject;
    TommiGUIScript TGScript;

    /*static bool first = true;
    bool instNew;*/

    GameObject[] theList;
    public GameObject newLaser;

    RaycastHit hit;
    Vector3 tempTarget = new Vector3(50, 0, 0);

    bool checkedRay = false;

    void Awake()
    {
        eSettings = gameObject.GetComponent<EffectSettings>();

        //instNew = false;

        eSettings.MoveVector = tempTarget;

        //UIObject = GameObject.Find("UI");
        //TGScript = UIObject.GetComponent<TommiGUIScript>();

        /*if (first)
        {
            eSettings.UseMoveVector = true;
            eSettings.MoveVector = tempTarget;
        }
        else
        {
            eSettings.UseMoveVector = false;
            theList = ClosestObject();
            //eSettings.Target = nearest;

            if (eSettings.Target == null)
            {
                eSettings.UseMoveVector = true;
                eSettings.MoveVector = tempTarget;
                return;
            }
        }*/
    }

    void Start()
    {
        //TGScript.LaserFired();
        
        /*if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            if (hit.collider.tag == "IonSphere" && !instNew)
            {
                
                //Debug.DrawRay(transform.position, nearest.transform.TransformVector(nearest.transform.position), Color.red, 10);
                first = false;
                Instantiate(newLaser, hit.transform.position, Quaternion.identity);
                instNew = true;

                MissileScript mScript = hit.collider.GetComponent<MissileScript>();
                mScript.ProjectileExplosion();
            }
            else
            {
                first = true;
            }
        }*/
    }

    void Update()
    {
        if (!checkedRay)
        {
            if (Physics.Raycast(transform.position, transform.right, out hit))
            {
                if (hit.collider.transform.tag == "IonSphere")
                {
                    theList = ClosestObject();
                    foreach (GameObject obj in theList)
                    {
                        MissileScript mScript = obj.GetComponent<MissileScript>();
                        mScript.ProjectileExplosion();
                    }
                }
                /*else if (hit.collider.transform.tag == "Enemy")
                {
                    ScoreAndDropScript SDScript = hit.collider.GetComponent<ScoreAndDropScript>();
                    SDScript.GiveScoreAndSP();
                }*/
                checkedRay = true;
            }
        }
    }

    /*Ray ray;
    RaycastHit hit;
    Vector3 rayDirection;
    bool shot;
    static bool first = true;
    Vector3 TempTarget = new Vector3(10, 0, 0);
    Transform nearest;

    EffectSettings eSettings;

    void Start()
    {
        rayDirection = transform.right;

        eSettings = gameObject.GetComponent<EffectSettings>();

        nearest = ClosestObject();

        if(!first && nearest != null)
        {
            Debug.Log(nearest);
            eSettings.MoveVector = nearest.transform.position;
        }
        else
        {
            eSettings.MoveVector = TempTarget;
        }
    }

    void Update()
    {
        if(!shot)
        {
            if(Physics.Raycast(transform.position, rayDirection, out hit))
            {
                if(hit.collider.transform.tag == "IonSphere")
                {
                    first = false;
                    MissileScript mScript = hit.collider.GetComponent<MissileScript>();
                    mScript.ProjectileExplosion();
                }
                else
                {
                    first = true;
                }
                Debug.Log(first);
            }
            shot = true;
        }
    }*/

    GameObject[] ClosestObject()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("IonSphere");
        /*int i = 0;
        foreach (GameObject obj in allObjects)
        {
            print("This is " + i + "th. " + allObjects[i].transform.position);
            i++;
        }*/
        //GameObject closest = allObjects[0];
        return allObjects;
    }
}