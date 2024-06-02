// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Networking;
// using System.Text.RegularExpressions;

// using Mir;
// using Mir.Core;
// using UnityEngine.Events;
// using Mir.Responses;
// using Mir.Body;

// public class LoginMenuController : MonoBehaviour
// {
//     public InputField input_enterYourSeed;

//     [Header("All Wallet Menus")]
//     [Tooltip("All Wallet Meuns like saveKey, Information and other panels for enable selected one")]
//     public GameObject[] walletSCreens;

//     // For Save Key Menu ...
//     [Header("Save Key Screen")]
//     [Tooltip("All UI texts for populate seed splited strings or words")]
//     [SerializeField]
//     private Text[] seedText = new Text[12];

//     // For Information Screen
//     [Header("Infromation Screen")]
//     [SerializeField]
//     private InputField _userName;
//     [SerializeField]
//     private InputField _email;
//     [SerializeField]
//     private InputField _phoneNumber;

//     // For Enter Your Seed
//     [Header("Enter Your Seed Screen")]
//     public InputField enterSeed;

//     public void Logout()
//     {
//         DataCentre.Token = "";
//     }

//     private void OnEnable()
//     {
//         //DataCentre.EmptySaveables();

//         Utils.Log("Token = " + DataCentre.Token + " ");

//         Utils.Log("Token = " + DataCentre.Token + " Public Key = " + DataCentre.PublicKey);
//         if (DataCentre.Token == "" && DataCentre.PublicKey == "")
//         {
//             // user never logged in
//             setAllWalletScreens();
//             enableWalletScreen("WalletMenu");
//         }
//         else
//         {
//             // user already have wallet
//             if (Init() )
//             {
//                 // open main menu
//                 MenuManager.Instance.OpenScreen("MainMenu");
//             }
//             else
//             {
//                 // Open API Loading ...
//                 MenuManager.Instance.EnableAPILoading(true);

//                 GetNonce((string response) =>
//                 {
//                     API_RESPONSE<Nonce_Response> result = JsonUtility.FromJson<API_RESPONSE<Nonce_Response>>(response);
//                     if (result.status == 200)
//                     {
//                         MenuManager.Instance.EnableAPILoading(false);
//                         DataCentre.ID = result.data.id;
//                         string signature = DracoArts.Instance.blockchainManager.SignMessage(result.data.nonce, DataCentre.PublicKey.ToLower());
//                         Utils.Log("My Signature " + signature);
//                         LoginWithWallet(signature, (string r) =>
//                         {
//                             if (result.status == 200)
//                             {
//                                 API_RESPONSE<LoginwithWallet_Response> result = JsonUtility.FromJson<API_RESPONSE<LoginwithWallet_Response>>(r);

//                                 DataCentre.Token = result.data.token;
//                                 Utils.Log(DataCentre.Token);
//                                 // open other menu
//                                 MenuManager.Instance.OpenScreen("MainMenu");
//                             }
//                         });
//                     }
//                     else if (result.status == 400)
//                     {
//                         // popup message
//                         MenuManager.Instance.EnableAPILoading(false);

//                     }
//                     //
//                 });
//             }
//         }

//         _phoneNumber.characterValidation = InputField.CharacterValidation.Integer;
//         _email.characterValidation = InputField.CharacterValidation.EmailAddress;
//     }

//     // For Email Input Feild
//     public bool IsValidEmail(string email)
//     {
//         Regex emailRegex = new Regex(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", RegexOptions.IgnoreCase);
//         return emailRegex.IsMatch(email);
//     }

//     bool Init()
//     {
//         //API TO CHECK SESSION IS ACTIVE
//         return true;
//     }

//     #region Wallet Screen Enable
//     void setAllWalletScreens()
//     {
//         walletSCreens = new GameObject[transform.childCount];
//         for (int i = 0; i < walletSCreens.Length; i++)
//         {
//             walletSCreens[i] = transform.GetChild(i).gameObject;
//         }
//     }
//     void enableWalletScreen(string screenName)
//     {
//         for (int i = 0; i < walletSCreens.Length; i++)
//         {
//             walletSCreens[i].SetActive(walletSCreens[i].name == screenName ? true : false);
//         }
//     }
//     #endregion

//     #region APIS
//     void GetWalletKeys(UnityAction<bool> action)
//     {
//         try
//         {
//             if (enterSeed.text != "")
//             {
//                 DracoArts.Instance.blockchainManager.RecoverAccount(input_enterYourSeed.text, "", (BlockChainKeys keys) =>
//                 //DracoArts.Instance.blockchainManager.RecoverAccount("reflect napkin kitten bench prize palace minimum pulse share pitch type foil", "", (BlockChainKeys keys) =>
//                 {
//                     DataCentre.PrivateKey = keys.privateKey;
//                     DataCentre.PublicKey = keys.publicKey;
                    
//                     print("==================Keys==========================");
//                     print("PK " + DataCentre.PrivateKey);
//                     print("Public Key " + DataCentre.PublicKey);
//                     print("==================Keys==========================");
//                     action(true);
//                 });
//             }
//         }
//         catch (System.Exception)
//         {
//             throw;
//         }
//     }

//     void GetNonce(UnityAction<string> action)
//     {
//         try
//         {
//             Dictionary<string, string> header = new Dictionary<string, string>();
//             header.Add("Content-Type", "application/json");

//             DracoArts.Instance.apiManager.CALL("/getNonce/" + DataCentre.PublicKey.ToLower(), CRUD.GET, "", header, (string response) => {
//                 print("==================Get Nonce==========================");
//                 print(response);
//                 print("==================Get Nonce==========================");
//                 action(response);
//             });
//         }
//         catch (System.Exception e)
//         {
//             Utils.Log(e.Message);
//         }
//     }

//     void LoginWithWallet(string signature,UnityAction<string> action) 
//     {
//         try
//         {
//             print("PUBLIC KEY = " + DataCentre.PublicKey);
//             print("PRIVATE KEY = " + DataCentre.PrivateKey);

//             Dictionary<string, string> header = new Dictionary<string, string>();
//             header.Add("Content-Type", "application/json");

//             LoginWallet_Body obj = new LoginWallet_Body(DataCentre.PublicKey, signature);

//             //Loading Open
//             DracoArts.Instance.apiManager.CALL("/loginWithWallet", CRUD.POST, JsonUtility.ToJson(obj), header, (string response) =>
//             {
//                 print("==================Login With Wallet==========================");
//                 print(response);
//                 print("==================Login With Wallet==========================");
//                 action(response);
//                 //Close Loading
//             });
//         }
//         catch (System.Exception e)
//         {
//             Utils.Log(e.Message);
//         }
//     }
//     #endregion

//     #region User Interactions

//     #region Wallet (Create And Import)

//     /// <summary>
//     /// Creating Wallet
//     /// </summary>
//     public void CreateWallet()
//     {
//         try
//         {
//             DataCentre.Mnemonic = DracoArts.Instance.blockchainManager.GenerateRandomMnemonic();
//             DracoArts.Instance.blockchainManager.CreateHDWallet(DataCentre.Mnemonic, "", (BlockChainKeys keys) =>
//             {
//                 DataCentre.PrivateKey = keys.privateKey;
//                 Debug.Log("***************Private Key***************");
//                 Debug.Log("" + keys.privateKey);
//                 DataCentre.PublicKey = keys.publicKey;
//                 Debug.Log("***************Public Key***************");
//                 Debug.Log("" + keys.publicKey);

//                 GetNonce((string response) =>
//                 {
//                     API_RESPONSE<Nonce_Response> result = JsonUtility.FromJson<API_RESPONSE<Nonce_Response>>(response);
//                     if (result.status == 200)
//                     {
//                         DataCentre.ID = result.data.id;
//                         string signature = DracoArts.Instance.blockchainManager.SignMessage(result.data.nonce, DataCentre.PublicKey);
//                        // print("My Signature " + signature);
//                         LoginWithWallet(signature, (string r) =>
//                         {
                           
//                             API_RESPONSE<LoginwithWallet_Response> result = JsonUtility.FromJson<API_RESPONSE<LoginwithWallet_Response>>(r);
//                             if (result.status == 200)
//                             {
                               
//                                 print(result.data.token);
//                                 DataCentre.Token = result.data.token;
                                
//                                 // open other menu

//                                 // Set Seeds in All Texts
//                                 setSeedText(DataCentre.Mnemonic);
//                                 enableWalletScreen("SaveKey");
//                             }
//                             else
//                             {
//                                 print(result.message);

//                                 // Appears pop up with error ...
//                             }
//                         });
//                     }
//                     else if (result.status == 400)
//                     {
//                         // popup message

//                     }
//                 });
//             });
//         }
//         catch (System.Exception e)
//         {
//             Utils.Log(e.Message);
//         }
//     }

//     public void ImportWalletClick()
//     {
//         enableWalletScreen("importseedMenu");
//     }
//     #endregion

//     #region Enter Your Seed

//     public void BackFromEnterYourSeed()
//     {
//         enableWalletScreen("WalletMenu");
//     }

//     /// <summary>
//     /// Importing Wallet
//     /// </summary>
//     public void ImportWallet()
//     {
//         try
//         {
//             MenuManager.Instance.EnableAPILoading(true);
//             GetWalletKeys((bool r) =>
//             {
//                 if (r)
//                 {
//                     GetNonce((string response) =>
//                     {
//                         API_RESPONSE<Nonce_Response> result = JsonUtility.FromJson<API_RESPONSE<Nonce_Response>>(response);
//                         if (result.status == 200)
//                         {
//                             DataCentre.ID = result.data.id;
//                             string signature = DracoArts.Instance.blockchainManager.SignMessage(result.data.nonce, DataCentre.PublicKey.ToLower());
//                             print("My Signature " + signature);
//                             LoginWithWallet(signature, (string r) =>
//                             {
//                                 if (result.status == 200)
//                                 {
//                                     API_RESPONSE<LoginwithWallet_Response> result = JsonUtility.FromJson<API_RESPONSE<LoginwithWallet_Response>>(r);

//                                     DataCentre.Token = result.data.token;
                                    
//                                     // open other menu
//                                     MenuManager.Instance.EnableAPILoading(false);
//                                     MenuManager.Instance.OpenScreen("MainMenu");
//                                 }
//                             });
//                         }
//                         else if (result.status == 400)
//                         {
//                             // popup message
//                             Utils.Log(" Status = 400" + result.message);
//                         }
//                         //
//                     });
//                 }
//                 else
//                 {
//                     MenuManager.Instance.EnableAPILoading(false);
//                 }
//             });
//         }
//         catch (System.Exception e)
//         {
//             MenuManager.Instance.EnableAPILoading(false);
//             Utils.Log(e.Message);
//         }
//     }

    

//     #endregion

//     #region Save Key Screen
//     /// <summary>
//     /// Copy Mnemonic to Clip Board For Further Use.
//     /// </summary>
//     public void copyButton()
//     {
//         Utils.CopyToClipBoard(DataCentre.Mnemonic);
//     }

//     /// <summary>
//     /// Continue Button Click Event For Save Key Screen ...
//     /// </summary>
//     public void ContinueButtonClickSaveKeyScreen()
//     {
//         // If User Does Not click copy button ...
//         Utils.CopyToClipBoard(DataCentre.Mnemonic);
//         // If other things have to be done here ...

//         enableWalletScreen("Information");
//     }

//     /// <summary>
//     /// Setting the Seed values to Text
//     /// </summary>
//     /// <param name="txt"></param>
//     public void setSeedText(string txt)
//     {
//         //Debug.Log("TXT = " + txt);
//         List<string> temp = Utils.StringToList(txt, ' ');

//         for (int i = 0; i < temp.Count; i++)
//         {
//             seedText[i].text = temp[i];
//         }
//     }
//     #endregion

//     #region Information Screen
//     /// <summary>
//     /// Skip Button Click On Information Screen.
//     /// </summary>
//     public void SkipButtonClickInformationScreen()
//     {
//         MenuManager.Instance.OpenScreen("MainMenu");
//     }

//     /// <summary>
//     /// Continue Button Click For Information Screen.
//     /// </summary>
//     public void ContinueButtonClickInformationScreen()
//     {
//         if (_userName.text != "" && _email.text != "" && _phoneNumber.text != "")
//         {
//             try
//             {
//                 Dictionary<string, string> header = new Dictionary<string, string>();
//                 header.Add("Content-Type", "application/json");
//                 header.Add("Authorization", "Bearer " + DataCentre.Token);

//                 UpdateProfile_Body body = new UpdateProfile_Body(_userName.text, _phoneNumber.text, _email.text);
//                 DracoArts.Instance.apiManager.CALL("/updateProfile", CRUD.PUT, JsonUtility.ToJson(body), header, (string response) =>
//                 {
//                     API_RESPONSE<User_Null_Response> result = JsonUtility.FromJson<API_RESPONSE<User_Null_Response>>(response);
//                     if (result.status == 200)
//                     {
//                         // Storing user credentials in Data Center
//                         DataCentre.userName = _userName.text;
//                         DataCentre.email = _email.text;
//                         DataCentre.phoneNumber = _phoneNumber.text;

//                         // Opening Main Menu
//                         MenuManager.Instance.OpenScreen("MainMenu");
//                     }
//                     else
//                     {
//                         //Pop Up Controller ...
//                     }
//                     print(response);
//                 });
//             }
//             catch (System.Exception)
//             {
//                 throw;
//             }

//         }
//     }
//     #endregion Information Screen

//     #endregion User InterFace
// }