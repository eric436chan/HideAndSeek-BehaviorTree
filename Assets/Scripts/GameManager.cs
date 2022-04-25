using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public bool shortSpotted = false;
    public bool longSpotted = false;
    public bool heard = false;

    public NavMeshAgent hider;

    public Transform memoryPrefab;
    public Transform noisePrefab;

    public Transform memoryObject = null;
    public Transform noiseObject = null;

    public int randomSeekerPosition;
    public int randomHiderPosition;

    public Transform[] waypoints;
    private bool[] alreadyChecked;

    private void Start()
    {


        randomSeekerPosition = Random.Range(0, waypoints.Length);
        randomHiderPosition = Random.Range(0, waypoints.Length);
        hider.transform.position = waypoints[randomHiderPosition].position;
        alreadyChecked = new bool[waypoints.Length];

    }

    private void Update()
    {
        if (shortSpotted || longSpotted)
        {


            if (memoryObject == null)
            {
                memoryObject = Instantiate(memoryPrefab);
                
            }

            memoryObject.transform.position = hider.transform.position;
            

        }
    }

    public void generateRandomHiderPosition()
    {
        Debug.Log("Changing Position");




        int newPosition = Random.Range(0, waypoints.Length);

        if (newPosition == randomHiderPosition)
        {
            newPosition++;
            if (newPosition == waypoints.Length)
            {
                newPosition = 0;
            }
        }

        randomHiderPosition = newPosition;
    }

    public void generateRandomSeekerPosition()
    {
        Debug.Log("Changing Position");

        randomSeekerPosition++;
           
            if (randomSeekerPosition == waypoints.Length)
            {
                randomSeekerPosition = 0;
            }
        



       

    }


}
