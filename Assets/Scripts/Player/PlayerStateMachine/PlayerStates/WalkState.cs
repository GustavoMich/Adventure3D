using UnityEngine;
using Ebac.StateMachine;

public class WalkState : StateBase
{
    private PlayerStateMachine player;
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool returning;

    public WalkState(PlayerStateMachine player) : base()
    {
        this.player = player;
    }

    public override void OnStateEnter(object o = null)
    {
        startPos = player.transform.position;
        targetPos = startPos + player.transform.forward * player.walkDistance;
        returning = false;
        Debug.Log("Entered Walk");
    }

    public override void OnStateStay()
    {
        Vector3 dest = returning ? startPos : targetPos;
        player.transform.position = Vector3.MoveTowards(
            player.transform.position,
            dest,
            player.walkSpeed * Time.deltaTime
        );

        
        if (!returning && Vector3.Distance(player.transform.position, targetPos) < 0.01f)
            returning = true;
        else if (returning && Vector3.Distance(player.transform.position, startPos) < 0.01f)
            player.stateMachine.SwitchState(PlayerStateMachine.PlayerStates.IDLE);
    }

    public override void OnStateExit()
    {
        Debug.Log("Exiting Walk");
    }
}

