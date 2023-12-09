using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public IState m_CurrentState = null;

    public void SetState(IState newState)
    {
        if (m_CurrentState == newState) return;

        if (m_CurrentState != null)
            m_CurrentState.OnStateExit();

        m_CurrentState = newState;

        m_CurrentState.OnStateStart();

        StopAllCoroutines();

        StartCoroutine(m_CurrentState.StateCoroutine());
    }
}
