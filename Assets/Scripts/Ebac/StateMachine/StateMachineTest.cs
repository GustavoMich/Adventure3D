using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateMachineTest : MonoBehaviour
{
    public enum States
    {
        IDLE,
        MOVE,
        JUMP
    }

    public Dictionary<States, StateBaseTest> dictionaryState;


    private StateBaseTest _currentState;
    public PlayerController player;
    public float timeToStartMove = 1f;
    public float timeToStartJump = 1f;


    private void Awake()
    {
        dictionaryState = new Dictionary<States, StateBaseTest>();
        dictionaryState.Add(States.IDLE, new StateBaseTest());
        dictionaryState.Add(States.MOVE, new StateMove());
        dictionaryState.Add(States.JUMP, new StateJump());

        SwitchState(States.IDLE);

        Invoke(nameof(StartMove), timeToStartMove);

        Invoke(nameof(StartToJump), timeToStartJump);
    }

    private void StartMove()
    {
        SwitchState(States.MOVE);
    }

    private void StartToJump()
    {
        SwitchState(States.JUMP);
    }


    public void SwitchState(States state)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryState[state];

        _currentState.OnStateEnter(player);
    }

    public void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }
}
