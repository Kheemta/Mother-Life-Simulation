using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour
{

    [SerializeField]
    private Alert alert;
    [SerializeField]
    private MessagePopUp message;
    [SerializeField]
    private ToastPopup toast;
  
    public void ShowPopUp(PopupResponse popup)
    {     
         alert.Show(popup); 
    }

    public void ShowPopUp(DecisionBox popup)
    {
        message.Show(popup);
    }

    public void ShowFlipUp(ToastResponse popup)
    {
        toast.Show(popup);
    }

}
