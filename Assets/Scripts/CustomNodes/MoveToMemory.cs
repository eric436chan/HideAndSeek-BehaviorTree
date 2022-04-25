using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveToMemory : ActionNode
{

    public float speed = 3;
    public float stoppingDistance = 0.1f;
    public bool updateRotation = true;
    public float tolerance = 1.0f;

    protected override void OnStart()
    {
        context.agent.stoppingDistance = stoppingDistance;
        context.agent.speed = speed;
        context.agent.destination = blackboard.memoryObject.position;
        context.agent.updateRotation = updateRotation;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {

        if (FindObjectOfType<GameManager>().shortSpotted || FindObjectOfType<GameManager>().longSpotted || FindObjectOfType<GameManager>().heard)
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
            return State.Failure;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            return State.Failure;
        }

        return State.Running;
    }
}
