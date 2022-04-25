using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TheKiwiCoder;

public class MoveToHider : ActionNode
{
    public float speed = 12;
    public float stoppingDistance = 0.1f;
    public bool updateRotation = true;
    public float tolerance = 2.0f;

    protected override void OnStart() {
        context.agent.stoppingDistance = stoppingDistance;
        context.agent.speed = speed;
        blackboard.hider = FindObjectOfType<GameManager>().hider;
        context.agent.destination = blackboard.hider.transform.position;
        context.agent.updateRotation = updateRotation;
        
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {


        context.agent.destination = blackboard.hider.transform.position;

        if (!FindObjectOfType<GameManager>().shortSpotted && !FindObjectOfType<GameManager>().longSpotted)
        {
            return State.Failure;
        }

        if (context.agent.pathPending)
        {
            return State.Running;
        }

        if (context.agent.remainingDistance < tolerance)
        {
            Debug.Log(Time.realtimeSinceStartup);
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
            return State.Success;
        }

        if (context.agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
        {
            return State.Failure;
        }

        return State.Running;
    }
}
