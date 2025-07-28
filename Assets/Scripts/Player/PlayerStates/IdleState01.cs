using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class IdleState01 : StateBase
{
    public override void OnStateEnter(object o = null)
    {
        Debug.Log("Idle");
    }
}
