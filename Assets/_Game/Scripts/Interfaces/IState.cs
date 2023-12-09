using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void OnStateStart();
    public void OnStateUpdate();
    public void OnStateExit();
    public IEnumerator StateCoroutine();
}
