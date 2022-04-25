using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckHearing : ActionNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        if (FindObjectOfType<GameManager>().heard)
        {

            blackboard.heard = true;
            blackboard.noiseObject = FindObjectOfType<GameManager>().noiseObject;
        }
        else
        {
            blackboard.heard = false;
        }

        State state = blackboard.heard ? State.Success : State.Failure;


        return state;
    }
}
