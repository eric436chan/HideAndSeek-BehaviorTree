using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckVision : ActionNode
{
    protected override void OnStart()
    {
        blackboard.spotted = false;
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {



        if (FindObjectOfType<GameManager>().shortSpotted || FindObjectOfType<GameManager>().longSpotted)
        {

            blackboard.spotted = true;
        }
        else
        {
            blackboard.spotted = false;
        }

        State state = blackboard.spotted ? State.Success : State.Failure;

        
        return state;
       
    }
}
