using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using DG.Tweening;


public class ToastPopup : MonoBehaviour
{
    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private float _delay;
    public void OnEnable()
    {
        _container.SetActive(false);
    }
    public void Show(ToastResponse obj)
    {
        _text.text = obj.data;
        _container.SetActive(true);
      //  FindObjectOfType<_AnimationPopup>().AnimationFlipUp();   // transform.DOMoveY(15, 1.0f).SetEase(Ease.InOutSine);
        Invoke("Hide", _delay);
    }
    public void Hide()
    {
        _container.SetActive(false);
    }
}
