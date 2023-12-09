using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private StatesController statesController;

    public IdleState(StatesController statesController)
    {
        this.statesController = statesController;
    }
    public void OnStateExit()
    {
    }

    public void OnStateStart()
    {
        statesController.CurrentStateType = State.IDLE_STATE;
    }

    public void OnStateUpdate()
    {
    }

    public IEnumerator StateCoroutine()
    {
        yield return null;
    }

}
