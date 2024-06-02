using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class PopupResponse 
{
    public string data;
}

[System.Serializable]
public class DecisionBox
{
    public string title;
    public string message;
    public string okButtonText;
    public string cancelButtonText;

    public UnityAction <string> okAction  ;
    public UnityAction <string> cancelAction ;

    public DecisionBox(string title, string message, string okButtonText, string cancelButtonText)
    {
        this.title = title;
        this.message = message;
        this.okButtonText = okButtonText;
        this.cancelButtonText = cancelButtonText;
       
    }
    
}

[System.Serializable]
public class ToastResponse
{
    public string data; 
}




