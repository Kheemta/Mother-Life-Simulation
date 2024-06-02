using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
[CreateAssetMenu]
public class MotherGamePlayValidStates : ScriptableObject
{
    public List<ValidState<MotherStates>> states; 

    public bool isValidState(MotherStates currentState, MotherStates nextState)
    {
        bool value = false;
        states.ForEach(e=> { 
           if(e.currentState == currentState)
           {
                value = e.validStates.Contains(nextState);
            }
           
       });
       return value;
    }
}




