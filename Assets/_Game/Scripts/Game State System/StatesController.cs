using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    WIN_STATE,
    FAIL_STATE,
    IDLE_STATE,
}
public class StatesController : StateManager
{
    public static StatesController Instance;
    private State currentStateType;
    public IState WinState, FailState, IdleState;
    public IState CurrentState { get; private set; }

    public State CurrentStateType
    {
        get { return currentStateType; }
        set { currentStateType = value; }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }
    private void Start()
    {
        WinState = new WinState(this);
        FailState = new FailState(this);
        IdleState = new IdleState(this);
        SetState(IdleState);
    }

}
