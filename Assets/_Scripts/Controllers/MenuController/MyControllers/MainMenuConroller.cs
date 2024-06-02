using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mir.Responses;



namespace Mir
{
    public class MainMenuConroller : MonoBehaviour
    {
        [Header("Fetch From API")]
        [SerializeField]
        private Text nameText;
        [SerializeField]
        private Text levelText;
        [SerializeField]
        private Text levelNo;

        private  int _playerLevel;
        private  float _levelProgress;
        private  string _playerName;

        //Menu 3d Character
        public GameObject character;


        // Fetch User Data From API
        void FetchUserData()
        {

            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Content-Type", "application/json");
                //header.Add("Authorization", "Bearer " + DataCentre.Token);

                DracoArts.Instance.apiManager.CALL("/getUser", CRUD.GET, "", header, (string response) =>
                {
                    API_RESPONSE<GetSingleUser_Response> result = JsonUtility.FromJson<API_RESPONSE<GetSingleUser_Response>>(response);
                    if (result.status == 200)
                    {
                        nameText.text = result.data.uName.ToUpper();
                    }
                    else
                    {
                        nameText.text = "error";
                    }
                });
            }
            catch (System.Exception e)
            {
                print(e.Message);
            }
        }

        public void ZombieCity()
        {
            MenuManager.Instance.LoadScene(this.gameObject, null, "Env_Light Baked");
        }

        public void PoliceStation()
        {
            MenuManager.Instance.LoadScene(this.gameObject, null, "Police Station_Light_Baked");
        }

        private void Awake()
        {
            character.SetActive(false);
        }

        private void OnEnable()
        {
            StartCoroutine(activatingCharacter(0.01f));
            FetchUserData();
        }

        private void Start()
        {
            
        }

        IEnumerator activatingCharacter(float val)
        {
            yield return new WaitForSeconds(val);
            character.SetActive(true);
        }

        private void OnDisable()
        {
            character.SetActive(false);
        }
        public void PauseGame()
        {
            DracoArts.Instance.gameManager.Trigger(EventType.GameStateEvent, "GamePause");

        }
        public void GameResume()
        {
            DracoArts.Instance.gameManager.Trigger(EventType.GameStateEvent, "GameResume");
        }

        // The methods below would be change according to requirement.
        public void MultiplayerQuest()
        {
            MenuManager.Instance.LoadScene(this.gameObject, null, "MultiplayerMenu");  
        }

        public void ZombieCity(GameObject temp)
        {
            SceneManager.LoadScene("Chapter1Exterior");
            temp.SetActive(false);
        }

        public void OpenGameLink(string link)
        {
            Application.OpenURL(link);
        }
    }
}
