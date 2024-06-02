using Mir;
using Mir.Responses;
using UnityEngine;
using UnityEngine.UI;

public class ForgotPassword : MonoBehaviour
{
    [SerializeField]
    private InputField _email;

    [SerializeField]
    private GameObject _popUp;
    [SerializeField]
    private Text _reponse;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OnClickResetPassword()
    {
        string email = _email.text;
        WWWForm form = new WWWForm();

        form.AddField("email", email);

       // DracoArts.Instance.apiManager.FETCH("/requestPasswordReset", form, PasswordResetReturn);
    }
    public void PasswordResetReturn(string data)
    {
        Debug.Log(data);

        Request_PasswordReset response = JsonUtility.FromJson<Request_PasswordReset>(data);

        if (response.objectId == null)
        {
            _popUp.SetActive(true);
            _reponse.text = response.error.ToString();
        }
        else if (response.objectId != null)
        {

        }

        Debug.Log("Object ID" + response.objectId);
        Debug.Log("Session Token" + response.sessionToken);

        Debug.Log("Status" + response.code);
        Debug.Log("Errror" + response.error);
    }
}
