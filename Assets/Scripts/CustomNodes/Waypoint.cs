using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hider")
        {
            Debug.Log("Hider Entered");
            FindObjectOfType<GameManager>().generateRandomHiderPosition();
        }else if(other.tag == "Seeker")
        {
            Debug.Log("Seeker Entered");
            FindObjectOfType<GameManager>().generateRandomSeekerPosition();
            
        }
    }



}
