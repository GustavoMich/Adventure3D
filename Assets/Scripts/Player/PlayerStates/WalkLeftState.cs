using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;

public class WalkLeftState : StateBase
{
    private Transform mytransform;

    public WalkLeftState(Transform t)
    {
        mytransform = t;
    }

    public override void OnStateStay()
    {
        mytransform.Translate(Vector3.left * Time.deltaTime * 3f);
        Debug.Log("WalkingLeft");
    }
}
