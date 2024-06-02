using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mir;
public class Trigger : MonoBehaviour
{
    public string data;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DracoArts.Instance.gameManager.Trigger(Mir.EventType.GameStateEvent, "GameStateChange", data);

            Debug.Log("reaCHED");
        }
    }

}
