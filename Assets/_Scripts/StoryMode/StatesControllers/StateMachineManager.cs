using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineManager<T> : MonoBehaviour
{
    public abstract void setCurrentState(T nextState);

    protected abstract void HandleMenus(T currentState);
    public abstract void HandleGameObjects(T currentState);
    protected abstract void HandleData(T currentState);
    protected abstract void HandleCutScene(T currentState); 

}
