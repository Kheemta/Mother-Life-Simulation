using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mir;
using Mir.Responses;

public class Login : MonoBehaviour
{
    [SerializeField]
    private InputField _userName;
    [SerializeField]
    private InputField _password;
   [SerializeField]
    private GameObject _popUp;
  //  [SerializeField]
  //  private Text _reponse;

    [SerializeField]
    private MainMenuConroller _mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickLogin()
    {
        string userName = _userName.text;
        string password = _password.text;
        WWWForm form = new WWWForm();
        form.AddField("username", userName);
        form.AddField("password", password);

        Debug.Log(userName);
        Debug.Log(password);

        /*  DracoArts.Instance.apiManager.FETCH("/login", form, (string data) =>
          {


              //Debug.Log(data);

              //DecisionBox box = new DecisionBox("test", "test", "test", "test");

              //box.okAction += (string d) =>
              //{
              //    Debug.Log("Aha " + d);
              //};


              //MenuManager.Instance._popupController.ShowPopUp(box);



              API_RESPONSE<Login_Response> response = JsonUtility.FromJson<API_RESPONSE<Login_Response>>(data);  //API fetching from DB

              Debug.Log(response.message);
              if (response.status == 200) //if data fetch successfully
              {
                  MenuManager.Instance.OpenScreen(_mainMenu.gameObject);    //showing data on screen
              }
              else
              {
                 // _popUp.SetActive(true);
              }


             
            Debug.Log("Object ID" + response.data.objectId);
         Debug.Log("Session Token" + response.data.sessionToken);
        Debug.Log("Status" + response.data.code);
    });*/
    
    }
  
}

