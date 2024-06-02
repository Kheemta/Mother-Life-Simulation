using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Alert : MonoBehaviour
{

    [SerializeField]
    private Text _messageText;

    [SerializeField]
    private GameObject _container;

    [SerializeField]
    private float _delay;



    void OnEnable()
    {
        _container.SetActive(false);
    }


    public void Show(PopupResponse obj)
    {
        //_messageText.text  obj.data;
        _container.SetActive(true);
        Invoke("Hide", _delay);
    }

    void Hide()
    {
        _container.SetActive(false);
    }
}
