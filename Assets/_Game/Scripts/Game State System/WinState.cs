using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : IState
{
    private StatesController statesController;

    public WinState(StatesController statesController)
    {
        this.statesController = statesController;
    }
    public void OnStateExit()
    {
    }

    public void OnStateStart()
    {
        statesController.CurrentStateType = State.WIN_STATE;
        UIManager.Instance.WinUI();

    }

    public void OnStateUpdate()
    {
    }

    public IEnumerator StateCoroutine()
    {
        yield return null;

    }


}
