using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _characters=new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //Utils.DisableListofGameObject(_characters);

        foreach (GameObject character in _characters)
        {
            character.transform.GetChild(0).gameObject.SetActive(false);
        }
        _characters[0].transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnClickCharacter(int i)
    {
        foreach (GameObject character in _characters)
        {
            character.transform.GetChild(0).gameObject.SetActive(false);
        }
        _characters[i].transform.GetChild(0).gameObject.SetActive(true);
    }
    public void OnClickBack()
    {

    }
    public void OnClickMarketPlace()
    {

    }
    public void OnClcikPrimaryWeapon()
    {

    }
    public void OnClickSwecondarWeapon()
    {

    }
   
    public void OnClickMeleeWeapon()
    {

    }
    public void OnClickAmigos()
    {

    }
}
