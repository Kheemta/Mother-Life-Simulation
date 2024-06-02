using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mir;
using Mir.Responses;
public class SignUpAPI : MonoBehaviour
{
    [SerializeField]
    private InputField _userName;
    [SerializeField]
    private InputField _password;
    [SerializeField]
    private InputField _phone;
    [SerializeField]
    private InputField _email;

    [SerializeField]
    private GameObject _popUp;
    [SerializeField]
    private Text _reponse;

    [SerializeField]
    private Login _login;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickSignUp()
    {
        string userName = _userName.text;
        string password = _password.text;
        string phone = _phone.text;
        string email = _email.text;

        WWWForm form = new WWWForm();

        form.AddField("username", userName);
        form.AddField("password", password);
        form.AddField("phone", phone);
        form.AddField("email", email);
        
        //DracoArts.Instance.apiManager.FETCH("/users",form, SignUpReturn);
    }
    public void SignUpReturn(string data)
    {
        Debug.Log(data);

       // SignUp_Response response = JsonUtility.FromJson<SignUp_Response>(data);

        API_RESPONSE<SignUp_Response> response = JsonUtility.FromJson<API_RESPONSE<SignUp_Response>>(data);  //API fetching from DB



        if (response.status == 201) //if data fetch successfully
        {
            MenuManager.Instance.OpenScreen(_login.gameObject);// showing login menu
        }


        else
        {
          //  _popUp.SetActive(true);
         //   _reponse.text = response.error.ToString();
        }

        Debug.Log("Object ID" + response.data.objectId);
        Debug.Log("Session Token" + response.data.sessionToken);
        Debug.Log("Status" + response.data.code);
        Debug.Log("Errror" + response.data.error);
    }
}
