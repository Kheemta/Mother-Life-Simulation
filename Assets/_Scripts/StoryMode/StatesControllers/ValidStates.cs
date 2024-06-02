using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ValidState<T>
{
    public T currentState;
    public List<T> validStates;
}
