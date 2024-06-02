using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonHandler : MonoBehaviour
{
    string screenName;
    private void OnEnable() { screenName = gameObject.name; GetComponent<Button>().onClick.AddListener(myButtonEvent); }
    void myButtonEvent() { Mir.MenuManager.Instance.OpenScreen(screenName); }
}
