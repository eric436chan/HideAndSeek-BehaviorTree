using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveToWaypoint : ActionNode
{

    public float duration = 1f;

    float startTime;

    public float speed = 3;
    public float stoppingDistance = 0.1f;
    public bool updateRotation = true;
    public float acceleration = 40.0f;
    public float tolerance = 1.0f;

    protected override void OnStart()
    {

        startTime = Time.time;

        FindObjectOfType<GameManager>().generateRandomHiderPosition();
        blackboard.waypoint = FindObjectOfType<GameManager>().waypoints[FindObjectOfType<GameManager>().randomHiderPosition];


        context.agent.stoppingDistance = stoppingDistance;
        context.agent.speed = speed;
        context.agent.destination = blackboard.waypoint.position;
        blackboard.hider = FindObjectOfType<GameManager>().hider;
        context.agent.updateRotation = updateRotation;
        context.agent.acceleration = acceleration;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {

        if (FindObjectOfType<GameManager>().shortSpotted || FindObjectOfType<GameManager>().longSpotted || FindObjectOfType<GameManager>().heard)
        {
            return State.Success;
        }

        if (Time.time - startTime > duration)
        {

            GameObject noiseObject = Instantiate(GameObject.Find("NoiseObject"));
            noiseObject.AddComponent<Noise>();
            noiseObject.transform.position = blackboard.hider.transform.position;
            Debug.Log("noise made");

            startTime = Time.time;
        }


        if (context.agent.pathPending)
        {
            
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance)
        {
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            return State.Failure;
        }

        return State.Running;
    }
}
