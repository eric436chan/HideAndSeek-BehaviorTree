using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    public bool origin;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Seeker")
        {
            Destroy(gameObject);
        }
    }
}
