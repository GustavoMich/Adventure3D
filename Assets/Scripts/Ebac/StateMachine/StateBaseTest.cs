using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateBaseTest 
{
    public virtual void OnStateEnter(object o = null)
    {
        Debug.Log("OnStateEnter");

    }

    public virtual void OnStateStay()
    {
        Debug.Log("OnStateStay");

    }

    public virtual void OnStateExit()
    {
        Debug.Log("OnStateExit");

    }


}

  public class StateMove : StateBaseTest
  {
    public PlayerController player;
    public override void OnStateEnter(object o = null)
    {
        player = (PlayerController)o;
        player.canMove = true;
        base.OnStateEnter(o);
    }

    public override void OnStateExit()
    {
        player.canMove = false;
        base.OnStateExit();
    }
  }

public class StateJump : StateBaseTest
{
    public PlayerController player;
    public override void OnStateEnter(object o = null)
    {
        player = (PlayerController)o;
        player.canMove = true;
        player.cantJump = false;
        base.OnStateEnter(o);
    }

    public override void OnStateExit()
    {
        player.canMove = false;
        player.cantJump = true;
        base.OnStateExit();
    }

    
}

