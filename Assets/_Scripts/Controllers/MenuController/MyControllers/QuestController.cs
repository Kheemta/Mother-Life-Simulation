using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mir.Core;
using Mir.Responses;
using Mir;
using UnityEngine.UI;
using System;

public class QuestController : MonoBehaviour
{
    [Header("UI")]
    public GameObject questTemplate;
    public GameObject scrollContent;

    [SerializeField]
    private GameObject[] panels;

    public void activatingPanel(int index)
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(index == i ? true : false);
        }
    }

    private void OnEnable()
    {
        GetAllQuest();
        activatingPanel(0);
    }

    void GetAllQuest()
    {
        try
        {
            Dictionary<string, string> header = new Dictionary<string, string>();

            header.Add("Content-Type", "application/json");
         //   header.Add("Authorization", "Bearer " + DataCentre.Token);

            DracoArts.Instance.apiManager.CALL("/getAllQuests", CRUD.GET, "", header, (string responce) =>
             {
                 API_RESPONSE<GetAllQuests_Response> result = JsonUtility.FromJson<API_RESPONSE<GetAllQuests_Response>>(responce);
                 if (result.status == 200)
                 {
                     //Instantiate Quest Scroller Content Object Here and fill Values ...
                     int index = 1;
                     result.data.Items.ForEach((SingleQuest_Response r) =>
                     {
                         GameObject obj = Instantiate(questTemplate) as GameObject;
                         obj.transform.SetParent(scrollContent.transform, false);
                         obj.GetComponent<QuestContentObject>().setData(r,index);
                         index++;
                     });

                   /*  for (int i = 0; i < result.data.Items.Count; i++)
                     {
                         
                       //  obj.SetActive(true);
                        // obj.GetComponent<QuestContentObject>().setData(i,result.data.Items[i].startTime, result.data.Items[i].endTime, result.data.Items[i].fee, result.data.Items[i].minAmount, result.data.Items[i].desc);
                       //  obj.GetComponent<QuestContentObject>().questId = result.data.Items[i].id;
                       //  obj.transform.SetParent(scrollContent.transform, false);
                     }*/
                 }
                 else
                 {
                     // print error here ...
                 }
             });
        }
        catch (System.Exception e)
        {
            print(e);
        }
    }
}
