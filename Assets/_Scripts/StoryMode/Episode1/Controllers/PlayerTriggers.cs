using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerTriggers : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI find_pch_text;

    [Header("CutScenes")]
    [SerializeField]
    private GameObject Stairway_TimeLine;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            find_pch_text.text = " ";
            Stairway_TimeLine.SetActive(true);
            StartCoroutine(Enable());

           
            //find_pch_text.textStyle = FontStyle.Normal
        }
    }

    public IEnumerator Enable()
    {
      yield return new WaitForSeconds(6);
    Stairway_TimeLine.SetActive(false);
        find_pch_text.text = " Find The Police officer";
    } 
}
