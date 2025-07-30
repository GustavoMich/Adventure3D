using Ebac.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("Walk Settings")]
    public float walkSpeed = 3f;
    public float walkDistance = 5f;

    [Header("Jump Settings")]
    public float jumpForce = 5f;
    public LayerMask groundMask;
    public float groundCheckDist = 0.5f;

    [HideInInspector] public Rigidbody Rb;


    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDist, groundMask);
    }



    public enum PlayerStates
    {
        IDLE,
        WALK,
        JUMP
    }

    public StateMachine<PlayerStates> stateMachine;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        Rb = GetComponent<Rigidbody>();

        stateMachine = new StateMachine<PlayerStates>();

        stateMachine.Init();
        stateMachine.RegisterStates(PlayerStates.IDLE, new IdleState(this));
        stateMachine.RegisterStates(PlayerStates.WALK, new WalkState(this));
        stateMachine.RegisterStates(PlayerStates.JUMP, new JumpState(this));
        

        stateMachine.SwitchState(PlayerStates.IDLE);

    }

    private void Update()
    {
        stateMachine.Update();

    }
}