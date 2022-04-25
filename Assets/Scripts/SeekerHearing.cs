using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerHearing : MonoBehaviour
{

    public float radius;
    public LayerMask layers;

    List<GameObject> Objects = new List<GameObject> ();
    Collider[] overlaps = new Collider[10];

    int count;

    // Update is called once per frame
    void Update()
    {
        if (Scan())
        {
            Debug.Log("heard");
            FindObjectOfType<GameManager>().heard = true;
        }
        else
        {
            FindObjectOfType<GameManager>().heard = false;
        }
    }

    private bool Scan()
    {
        count = Physics.OverlapSphereNonAlloc(transform.position, radius, overlaps, layers, QueryTriggerInteraction.Collide);
        Objects.Clear();

        for (int i = 0; i < count; ++i)
        {
            GameObject obj = overlaps[i].gameObject;

            if (obj != null)
            {
                FindObjectOfType<GameManager>().noiseObject = obj.transform;
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere (transform.position, radius);

        Gizmos.color = Color.green;
        foreach (GameObject obj in Objects)
        {
            Gizmos.DrawSphere(obj.transform.position, 0.2f);
        }

    }
}
