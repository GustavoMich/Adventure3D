using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class WalkRightState : StateBase
{
    private Transform mytransform;

    public WalkRightState(Transform t)
    {
        mytransform = t;
    }

    public override void OnStateStay()
    {
        mytransform.Translate(Vector3.right * Time.deltaTime * 3f);
        Debug.Log("WalkingRight");
    }
}
