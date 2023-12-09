using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailState : IState
{
    private StatesController statesController;

    public FailState(StatesController statesController)
    {
        this.statesController = statesController;

    }
    public void OnStateExit()
    {
    }

    public void OnStateStart()
    {
        statesController.CurrentStateType = State.FAIL_STATE;
        UIManager.Instance.LoseUI();
    }

    public void OnStateUpdate()
    {
    }

    public IEnumerator StateCoroutine()
    {
        yield return null;
    }
}
