using Ebac.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingState : StateBase
{
    private Rigidbody _myrb;

    public JumpingState(Rigidbody rb)
    {
        _myrb = rb;
    }

    public override void OnStateEnter(object o = null)
    {
        _myrb.AddForce(Vector3.up * 6f, ForceMode.Impulse);
        Debug.Log("JumpingState");
    }
}
