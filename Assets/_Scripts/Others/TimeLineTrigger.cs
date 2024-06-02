using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mir;
public class TimeLineTrigger : MonoBehaviour
{
    // Start is called before the first frame update
 

    public string data;
    public void OnTimeLineTriggerExit()
    {
        Debug.Log("Data Start " + data);
        DracoArts.Instance.gameManager.Trigger(Mir.EventType.GameStateEvent, "GameStateChange", data);
        Debug.Log("Data End " + data);
    }

}
