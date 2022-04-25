using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class RandomMove : ActionNode
{
    public float speed = 3;
    public float stoppingDistance = 0.1f;
    public bool updateRotation = true;
    public float tolerance = 0.5f;

    protected override void OnStart()
    {

        blackboard.waypoint = FindObjectOfType<GameManager>().waypoints[FindObjectOfType<GameManager>().randomSeekerPosition];

        context.agent.stoppingDistance = stoppingDistance;
        context.agent.speed = speed;
        context.agent.destination = blackboard.waypoint.position;
        context.agent.updateRotation = updateRotation;
    }

    protected override void OnStop()
    {

    }

    protected override State OnUpdate()
    {

        //blackboard.waypoint = FindObjectOfType<GameManager>().waypoints[FindObjectOfType<GameManager>().randomSeekerPosition];
        //context.agent.destination = blackboard.waypoint.position;

        if(FindObjectOfType<GameManager>().shortSpotted || FindObjectOfType<GameManager>().longSpotted || FindObjectOfType<GameManager>().heard)
        {
            Debug.Log("Detected");
            return State.Success;
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
            Debug.Log($"Bad waypoint: {FindObjectOfType<GameManager>().randomSeekerPosition}");
            return State.Failure;
        }

        return State.Running;
    }
}
