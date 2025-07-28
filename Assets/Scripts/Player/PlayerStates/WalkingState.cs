using Ebac.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : StateBase
{
    private Transform _transform;

    public WalkingState(Transform t)
    {
        _transform = t;
    }

    public override void OnStateStay()
    {
        _transform.Translate(Vector3.forward * Time.deltaTime * 3f);
        Debug.Log("Walking");
    }
}