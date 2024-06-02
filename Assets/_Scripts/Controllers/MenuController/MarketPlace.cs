using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketPlace : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _screens,_screensButtons=new List<GameObject>();
   
    // Start is called before the first frame update
    void OnEnable()
    {
        foreach (GameObject screen in _screens)
        {
            screen.SetActive(false);
        }
        Utils.DisableListofGameObject(_screens);
        _screens[0].SetActive(true);
        foreach (GameObject screen in _screensButtons)
        {
            screen.transform.GetChild(0).gameObject.SetActive(false);
        }
        _screensButtons[0].transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnClickWindows(int i)
    {
        foreach (GameObject screen in _screens)
        {
            screen.SetActive(false);
        }
        _screens[i].SetActive(true);
        foreach (GameObject screen in _screensButtons)
        {
            screen.transform.GetChild(0).gameObject.SetActive(false);
        }
        _screensButtons[i].transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnClickBack()
    {

    }
   
}
