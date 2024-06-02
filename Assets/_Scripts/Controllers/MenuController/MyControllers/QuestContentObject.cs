using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mir;
using Mir.Responses;

public class QuestContentObject : MonoBehaviour
{
    [Header("UI Memebers")]
    [SerializeField]
    private Text questIndex;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text enterFeeText;
    [SerializeField]
    private Text rewardText;
    [SerializeField]
    private Text descriptionText;

    public string questId = "";
    
    private void OnEnable()
    {
        this.GetComponent<Button>().onClick.AddListener(SingleQuest);
    }

    public void setData(int questIndex, double startTimer, double endTimer, string questFee, string questReward, string questDescription)
    {
        this.questIndex.text = (questIndex + 1).ToString();
        //timerText.text = Utils.GetTimeDuration(startTimer, endTimer);
        this.enterFeeText.text = questFee;
        this.rewardText.text = questReward;
        this.descriptionText.text = questDescription;
    }
    public void setData(SingleQuest_Response response,int index)
    {
        questId = response.id;
        this.questIndex.text = index.ToString();
        timerText.text = Utils.GetTimeDuration(response.startTime, response.endTime);
        this.enterFeeText.text = response.fee;
        this.rewardText.text = response.minAmount;
        this.descriptionText.text = response.desc;
    }
    void SingleQuest()
    {
        gameObject.SendMessageUpwards("activatingPanel", 1);

        //Sending Quest Id to single Quest ...
        Debug.Log("QuestContentObject Quest ID = " + questId);
        FindObjectOfType<SingleQuest>().questId = questId;

        //try
        //{

        //    Dictionary<string, string> header = new Dictionary<string, string>();
        //    header.Add("Content-Type", "application/json");
        //    header.Add("Authorization", "Bearer " + DataCentre.Token);
        //    DracoArts.Instance.apiManager.CALL("/getQuest/" + questId, CRUD.GET, "", header, (string responce) =>
        //      {
        //          API_RESPONSE<SingleQuest_Response> result = JsonUtility.FromJson<API_RESPONSE<SingleQuest_Response>>(responce);
        //          Debug.Log("Description = " + result.data.desc);
                  
        //      });
        //}
        //catch (Exception e)
        //{
        //    print(e);
        //}
    }
}
