using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckMemory : ActionNode
{
    protected override void OnStart()
    {
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (FindObjectOfType<GameManager>().memoryObject != null)
        {
            blackboard.memoryObject = FindObjectOfType<GameManager>().memoryObject;
            return State.Success;
        }
        else
        {
            return State.Failure;
        }

    }
}
