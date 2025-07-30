using UnityEngine;
using Ebac.StateMachine;

public class IdleState : StateBase
{
    private PlayerStateMachine player;

    public IdleState(PlayerStateMachine player) : base()
    {
        this.player = player;
    }

    public override void OnStateEnter(object o = null)
    {
        
        Debug.Log("Entered Idle");
    }

    public override void OnStateStay()
    {
        
        if (Input.GetKeyDown(KeyCode.W))
            player.stateMachine.SwitchState(PlayerStateMachine.PlayerStates.WALK);

        
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded())
            player.stateMachine.SwitchState(PlayerStateMachine.PlayerStates.JUMP);
    }

    public override void OnStateExit()
    {
        Debug.Log("Exiting Idle");
    }
}


