using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeekerShortVision : MonoBehaviour
{

    public GameObject hider;

    public float angle;
    public float radius;
    public LayerMask layers;
    public LayerMask occulusionLayers;

    List<GameObject> Objects = new List<GameObject> ();
    Collider[] overlaps = new Collider[10];
    int count;


    bool spotted = false;

    void Update()
    {
        spotted = Scan();
        //Debug.Log(spotted);
        if (spotted)
        {
            FindObjectOfType<GameManager>().shortSpotted = true;
            
        }
        else
        {
            FindObjectOfType<GameManager>().shortSpotted = false;
        }
        

    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(angle, transform.up) * transform.forward * radius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-angle, transform.up) * transform.forward * radius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (spotted)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }

        Gizmos.DrawRay(transform.position, (hider.transform.position - transform.position).normalized * radius);


        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * radius);

    }

    private bool Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, radius, overlaps, layers, QueryTriggerInteraction.Collide);
        Objects.Clear();

        Vector3 origin = transform.position;

        for (int i=0; i<count; ++i)
        {
            GameObject obj = overlaps[i].gameObject;

            if(obj != null)
            {
                if (obj == hider && inSight(hider))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool inSight(GameObject obj)
    {
        Vector3 origin = transform.position;
        Vector3 dest = obj.transform.position;
        Vector3 direction = dest - origin;

        direction.y = 0;
        float deltaAngle = Vector3.Angle(direction, transform.forward);

        if(deltaAngle > angle)
        {
            return false;
        }

        if(Physics.Linecast(origin, dest, occulusionLayers))
        {
            return false;
        }

        return true;

    }

    //public bool inFOV()
    //{
        
    //    int count = Physics.OverlapSphereNonAlloc(transform.position, radius, overlaps, layers, QueryTriggerInteraction.Collide);

    //    for (int i = 0; i < count; i++)
    //    {
    //        if(overlaps[i] != null)
    //        {
    //            if(overlaps[i].transform == hider)
    //            {
    //                Vector3 directionBetween = (hider.position - transform.position).normalized;
    //                directionBetween.y *= 0;

    //                float angleBetween = Vector3.Angle(transform.forward, directionBetween);

    //                if (angleBetween <= angle)
    //                {
    //                    Ray ray = new Ray(transform.position, hider.position - transform.position);
    //                    RaycastHit hit;

    //                    if (Physics.Raycast(ray, out hit, radius))
    //                    {
    //                        if (hit.transform == hider)
    //                        {

    //                            return true;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    return false;
    //}
}
