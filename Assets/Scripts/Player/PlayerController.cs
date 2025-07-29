using Ebac.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public Rigidbody _myrb;


    /*public enum CharacterState
    {
        Idle,
        Walking,
        Jumping,
        WalkRight,
        WalkLeft
    }

    void Start()
    {
        _myrb = GetComponent<Rigidbody>();
        stateMachine = new StateMachine<CharacterState>();
        stateMachine.Init();

        stateMachine.RegisterStates(CharacterState.Idle, new IdleState01());
        stateMachine.RegisterStates(CharacterState.Walking, new WalkingState(transform));
        stateMachine.RegisterStates(CharacterState.Jumping, new JumpingState(_myrb));
        stateMachine.RegisterStates(CharacterState.WalkRight, new WalkRightState(transform));
        stateMachine.RegisterStates(CharacterState.WalkLeft, new WalkLeftState(transform));



        stateMachine.SwitchState(CharacterState.Idle);
    }

    void Update()
    {
        stateMachine.Update();

        if (Input.GetKeyDown(KeyCode.W))
            stateMachine.SwitchState(CharacterState.Walking);

        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.SwitchState(CharacterState.Jumping);

        if (Input.GetKeyUp(KeyCode.W))
            stateMachine.SwitchState(CharacterState.Idle);

        if (Input.GetKeyDown(KeyCode.D))
            stateMachine.SwitchState(CharacterState.WalkRight);

        if (Input.GetKeyDown(KeyCode.A))
            stateMachine.SwitchState(CharacterState.WalkLeft);
    }*/
}
