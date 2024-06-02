using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePopUp : MonoBehaviour
{

    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private Text _message;
    [SerializeField]
    private Text _okButtonText;
    [SerializeField]
    private Text _cancelButtonText;

   
    DecisionBox data;
    public void OnEnable()
    {
        _container.SetActive(false);
    }
    public void Show(DecisionBox obj)
    {
        data = obj;
        _message.text = data.message;
        _container.SetActive(true);
    }
    public void Hide()
    {
        _container.SetActive(false);
    }

    public void OkButtonPressed(string val)
    {
        
        data.okAction(val);
        Hide();
    }

    public void cancelButtonPressed(string val)
    {
        data.cancelAction.Invoke(val);
        Hide();
    }




}





