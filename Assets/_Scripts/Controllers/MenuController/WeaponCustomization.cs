using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponCustomization : MonoBehaviour
{

    [SerializeField]
    private Image _damageImg, _fireRateImg, _controllImg, _accuracyImg, _rangeImg, _mobilityImg;

    [SerializeField]
    private List<GameObject> gunButtons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject screen in gunButtons)
        {
            screen.transform.GetChild(0).gameObject.SetActive(false);
        }
        gunButtons[0].transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnClickGun(int i)
    {
        foreach (GameObject screen in gunButtons)
        {
            screen.transform.GetChild(0).gameObject.SetActive(false);
        }
        gunButtons[i].transform.GetChild(0).gameObject.SetActive(true);

        _damageImg.fillAmount = Random.Range(0,1f);
        _fireRateImg.fillAmount = Random.Range(0,1f);
        _controllImg.fillAmount =Random.Range(0,1f);
        _accuracyImg.fillAmount = Random.Range(0,1f);
        _rangeImg.fillAmount = Random.Range(0,1f);
        _mobilityImg.fillAmount = Random.Range(0,1f);
    }
    public void OnClickBack()
    {

    }
    public void OnClickEquipped()
    {

    }
    public void OnClickUpGarde()
    {

    }
}
