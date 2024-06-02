// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// using Mir;
// using Mir.Body;
// using Mir.Responses;

// public class ProfileController : MonoBehaviour
// {
//     [Header("UI Interactions")]
//     public InputField inputField;
//     public Image profileImage;
//     public Image flagImage;
//     public Text rankText;
//     public Text friendsCountText;
//     public Text likesCountText;
//     public Text smiliesCountText;
//     public Image[] badgesEarned;
//     public Text playTimeText;
//     public Text matchesPlayed;
//     public Text achievementPointsText;
//     public Text seasonRatingText;
//     public Text seasonRankText;
//     public Text meritText;
//     public Text idText;

//     private void OnEnable()
//     {
        
//     }

//     void FetchUserData()
//     {
//         try
//         {
//             Dictionary<string, string> header = new Dictionary<string, string>();
//             header.Add("Content-Type", "application/json");
//             header.Add("Authorization", "Bearer " + DataCentre.Token);

//             UpdateProfile_Body obj = new UpdateProfile_Body(DataCentre.userName, DataCentre.phoneNumber, DataCentre.email);

//             DracoArts.Instance.apiManager.CALL("/updateProfile", CRUD.PUT, JsonUtility.ToJson(obj), header, (string responce) =>
//             {
                
//             });
//         }
//         catch (System.Exception e)
//         {
//             Utils.Log(e.Message);
//         }
//     }

//     public void EditClick()
//     {
        
//     }

// }
