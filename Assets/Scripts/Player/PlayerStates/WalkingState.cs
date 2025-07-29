using Ebac.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : StateBase
{
    private Transform mytransform;

    public WalkingState(Transform t)
    {
        mytransform = t;
    }

    public override void OnStateStay()
    {
        
        mytransform.Translate(Vector3.forward * Time.deltaTime * 3f);
        Debug.Log("Walking");
    }
}