using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterCustomization : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> _bodyPart = new List<GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {

        foreach (GameObject screen in _bodyPart)
        {

            screen.transform.GetChild(0).gameObject.SetActive(false);
        }
        _bodyPart[0].transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnClickPart(int i)
    {
        foreach (GameObject screen in _bodyPart)
        {
            screen.transform.GetChild(0).gameObject.SetActive(false);
        }
        _bodyPart[i].transform.GetChild(0).gameObject.SetActive(true);
    }


    public void OnClickBack()
    {

    }
    public void OnClickEquipped()
    {

    }
}
