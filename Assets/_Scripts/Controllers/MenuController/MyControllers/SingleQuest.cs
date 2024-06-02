using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mir;
using Mir.Responses;
using UnityEngine.Networking;

public class SingleQuest : MonoBehaviour
{
    [Header("UI Memebers")]
    [SerializeField]
    private Text sceneName;
    [SerializeField]
    private Text Description;
    [SerializeField]
    private Text Reward;
    [SerializeField]
    private Text Fee;
    [SerializeField]
    private Text RemianingTime;
    [SerializeField]
    private Image questImage;

    [Header("Members")]
    [HideInInspector]
    public string questId;  // Quest ID to get single Quest ...
    string URL;             // URL for downloading quest image ...

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        GetSingleQuest();
    }

    void GetSingleQuest()
    {
        // API .... to fetch single quest and populate data in UI Texts ...
        try
        {
            Debug.Log("Quest ID = " + questId);
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Content-Type", "application/json");
           // header.Add("Authorization", "Bearer " + DataCentre.Token);

            DracoArts.Instance.apiManager.CALL("/getQuest/" + questId, CRUD.GET, "", header, (string responce) =>
              {
                  API_RESPONSE<SingleQuest_Response> result = JsonUtility.FromJson<API_RESPONSE<SingleQuest_Response>>(responce);
                  Debug.Log("Description = " + result.data.desc);

                  if (result.status == 200)
                  {
                      sceneName.text = result.data.sceneName;
                      Description.text = result.data.desc;
                      Reward.text = result.data.minAmount;
                      Fee.text = result.data.fee;
                      RemianingTime.text = "00:00:00"; //Task Remaining ...
                      URL = result.data.image;
                      //URL = "https://i.postimg.cc/14xXkDt0/bgg.png";
                      Utils.Log("URL = " + URL);
                      StartCoroutine(Utils.GetTexture(URL, (Texture2D texture) => {
                          if (texture != null)
                          {
                              Rect rec = new Rect(0, 0, texture.width, texture.height);
                              Sprite spriteToUse = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 1);
                              questImage.sprite = spriteToUse;
                          }
                      }));
                  }
                  else
                  {
                      // Print Error ...
                  }
              });
        }
        catch (Exception e)
        {
            print(e);
        }
    }

    #region UI Button Events

    public void StartQuest()
    {

    }

    public void Back()
    {
        FindObjectOfType<QuestController>().activatingPanel(0);
        //gameObject.SendMessageUpwards("activatingPanel", 0);
        //gameObject.SendMessageUpwards("activatingPanel", "0");
        
    }

    #endregion
}
