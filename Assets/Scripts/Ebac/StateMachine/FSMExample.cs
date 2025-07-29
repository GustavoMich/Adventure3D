using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;


public class FSMExample : MonoBehaviour
{
    public PlayerController player;
    private Rigidbody _myrb;
    
    public Transform mytransform;


    public enum ExampleEnum
    {
      STATE_ONE,
      STATE_TWO,
      STATE_THREE
    }

  public StateMachine<ExampleEnum> stateMachine;


    private void Start()
    {
        _myrb = player.GetComponent<Rigidbody>();
        

        stateMachine = new StateMachine<ExampleEnum>();
        stateMachine.Init();
        stateMachine.RegisterStates(ExampleEnum.STATE_ONE, new IdleState01());
        stateMachine.RegisterStates(ExampleEnum.STATE_TWO, new WalkingState(mytransform));
        stateMachine.RegisterStates(ExampleEnum.STATE_THREE, new JumpingState(_myrb));


        stateMachine.SwitchState(ExampleEnum.STATE_ONE);



    }



    void Update()
    {

        stateMachine.Update();


        if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.SwitchState(ExampleEnum.STATE_TWO);

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SwitchState(ExampleEnum.STATE_THREE);

        }
        else if (Input.GetKeyDown(KeyCode.S))
            stateMachine.SwitchState(ExampleEnum.STATE_ONE);


    }

    

}
