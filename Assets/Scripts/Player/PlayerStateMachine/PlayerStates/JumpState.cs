using UnityEngine;
using Ebac.StateMachine;

public class JumpState : StateBase
{
   /* private PlayerStateMachine player;
    private bool hasJumped;

    public JumpState(PlayerStateMachine player) : base()
    {
        this.player = player;
    }

    public override void OnStateEnter(object o = null)
    {
        player.Rb.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
        hasJumped = true;
        Debug.Log("Entered Jump");
    }

    public override void OnStateStay()
    {
        
        if (hasJumped && player.IsGrounded())
            player.stateMachine.SwitchState(PlayerStateMachine.PlayerStates.IDLE);
    }

    public override void OnStateExit()
    {
        Debug.Log("Exiting Jump");
    }*/
}