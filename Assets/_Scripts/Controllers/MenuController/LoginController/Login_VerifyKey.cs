using Mir;
using Mir.Core;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Login_VerifyKey : MonoBehaviour
{

    [SerializeField]
    List<string> generatedWords = new List<string>();
    [SerializeField]
    List<Button> buttons;
    [SerializeField]
    Text completeString;
    [SerializeField]
    GameObject VerifyButton;
    [SerializeField]
    private GameObject _informationScreen;


    [SerializeField]
    private GameObject apiLoading;

    private void OnEnable()
    {
        VerifyButton.SetActive(false);
        //List<string> mnomic = Utils.StringToList(DataCentre.Mnemonic, ' ');
       // List<string> shuffle = Utils.ShuffleList(mnomic);



    }

    public void Enter(int i)
    {

        generatedWords.Add(buttons[i].transform.GetChild(0).GetComponent<Text>().text);
        buttons[i].gameObject.SetActive(false);
        completeString.text = "";

        generatedWords.ForEach(e =>
        {
            completeString.text += e + " ";
        });


        if (generatedWords.Count == 12)
        {

            VerifyButton.SetActive(true);

            //  Debug.Log("Actual String: "+ Utils.ListToString(generatedWords));
            // Debug.Log("Your String: " + Utils.TrimCharacter(DataCentre.Mnemonic, " "));

        }
    }
    public void Verify()
    {

        
        
     /*   if (Utils.TrimCharacter(DataCentre.Mnemonic, " ") == Utils.ListToString(generatedWords))
        {
            // create wallet

            Debug.Log("Equal");

            DracoArts.Instance.blockchainManager.CreateHDWallet(DataCentre.Mnemonic, "", (BlockChainKeys keys) =>
            {

                Debug.Log("Public key is: " + keys.publicKey);

                Debug.Log("Private key is: " + keys.privateKey);


                WWWForm body = new WWWForm();

                Debug.Log("/getNonce/" + keys.publicKey);

                DracoArts.Instance.apiManager.CALL("/getNonce/" + keys.publicKey, CRUD.GET, (string data) =>
                {

                    Debug.Log("Data"+data);

                    GetNonceResponse response = JsonUtility.FromJson<GetNonceResponse>(data);
                    DataCentre.id = response.data.id;

                    Debug.Log("+++++++++");  //user nonce id , public addreass

                    if (response.status == 200)
                    {
                        //
                        //Debug.Log("HEeeeeeyyyyyyyyyyyyyyyyyyy");
                        Debug.Log(response.data.nonce);

                        string signature = DracoArts.Instance.blockchainManager.SignMessage(response.data.nonce, keys.privateKey);
                        Debug.Log("+++++++++  "+data);

                        MenuManager.Instance.OpenPopup(apiLoading);

                        loginWithWallet_Body obj = new loginWithWallet_Body(keys.publicKey, signature);


                        //login
                        DracoArts.Instance.apiManager.CALL("/loginWithWallet/", JsonUtility.ToJson(obj), CRUD.POST, (string d) =>
                        {


                            loginWithWallet_Response b = JsonUtility.FromJson<loginWithWallet_Response>(d);
                            DataCentre.Token = b.data.token;

                            Debug.Log(d);

                            DataCentre.PrivateKey = keys.privateKey;
                            DataCentre.Save();
                            
                            MenuManager.Instance.OpenPopup(apiLoading,false);
                            // MenuManager.ApiLoadingScreen.SetActive(false);
                          //  Menu.Instance.OpenScreen(_informationScreen.gameObject);
                            _informationScreen.SetActive(true);
                            this.gameObject.SetActive(false);
                        });
                    }
                });
            });
        }
        else
        {
            DecisionBox box = new DecisionBox("test", "Invalid Input", "test", "test");
            box.okAction += (string d) =>
            {
                //  Debug.Log("Aha " + d);
            };
            MenuManager.Instance._popupController.ShowPopUp(box);

            generatedWords.Clear();
            //   Debug.Log("Please Try Again");
            buttons.ForEach(e => e.gameObject.SetActive(true));
            completeString.text = " ";
            VerifyButton.SetActive(true);
        }

        //dummy comparison
        //if (completeString.text == )
        //{
        //    Debug.Log("Matched " + "Actual String: " + mnomic + " Your string:" + " " + completeString.text);
        //}
        //else
        //{
        //    Debug.Log("Not Matched " + "Actual String: " + mnomic + "  " + " Your string: " + completeString.text);
        //    buttons.ForEach(e => e.gameObject.SetActive(true));
        //    completeString.text = " ";

        //    VerifyButton.SetActive(false);

        //    Debug.Log("Please Try Again");
        //}
        */
    }

    //public void Screen()
    //{

    //    Menu.Instance.OpenScreen(_informationScreen.gameObject);
    //}
    /// <summary>
    /// Azhar Add back button
    /// </summary>
    public void Back_Button()
    {

        generatedWords.Clear();
        //   Debug.Log("Please Try Again");
        buttons.ForEach(e => e.gameObject.SetActive(true));
        completeString.text = " ";
        VerifyButton.SetActive(true);
    }







    [System.Serializable]
    public class GetNonceResponse
    {
        public int status;
        public string message;
        public GetNonceResponseData data;

    }

    [System.Serializable]
    public class GetNonceResponseData
    {
        public string nonce;
        public string id;
    }


    [System.Serializable]
    public class loginWithWallet_Body
    {
        public string publicAddress;
        public string signature;

        public loginWithWallet_Body(string publicAddress, string signature)
        {
            this.publicAddress = publicAddress;
            this.signature = signature;
        }
    }
    [System.Serializable]
    public class loginWithWallet_Response
    {
        public int status;
        public string message;
        public loginWithWallet_Object data;
    }

    [System.Serializable]
    public class loginWithWallet_Object
    {
        public string token;
    }
}

