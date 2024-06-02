using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using Mir.Responses;
using UnityEngine.UI;
using UnityEngine.Networking;
namespace Mir
{
   

    public enum CRUD
    {
        POST,
        GET,
        PUT,
        PATCH,
        UPDATE
    }

    public class APIManager : MonoBehaviour
    {
        [SerializeField]
        private string BASE_URL;
    
     

        public void CALL(string endpoint="/",CRUD type = CRUD.GET, string body = "",Dictionary<string, string> headers=null, UnityAction<string> action=null)
        {
            StartCoroutine(API_CALL(BASE_URL + endpoint,type, body, headers, action));
        }



       

        void jsonData(byte[] jsonToSend, UnityWebRequest www, string form)
        {
            
            jsonToSend = new System.Text.UTF8Encoding().GetBytes(form);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        }


        IEnumerator API_CALL(string url, CRUD type, string form, Dictionary<string, string> headers, UnityAction<string> action)
        {
            UnityWebRequest www = null ;
            byte[] jsonToSend = null;
            switch (type)
            {
                case CRUD.POST:

                    www = UnityWebRequest.Post(url, form);
                    jsonData(jsonToSend, www, form);
                    break;
                case CRUD.GET:
                    www = UnityWebRequest.Get(url);
                    break;
                case CRUD.PUT:
                    www = UnityWebRequest.Put(url, form);
                    jsonData(jsonToSend, www, form);
                    break;
            }

            www.chunkedTransfer = false;

            if (headers != null)
            {
               foreach(KeyValuePair<string,string> entry in headers)
               {
                    www.SetRequestHeader(entry.Key, entry.Value);
               }
            }
           // www.SetRequestHeader("Content-Type", "application/json");
        
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error + " " + www.downloadHandler.text);
            }

            if (Mir.DracoArts.Instance.isDevelopment)
            {
                print("=================" + url + "====================");
                print(www.downloadHandler.text);
                print("=================" + url + "====================");
            }

            action(www.downloadHandler.text);
        }


        /*IEnumerator POST(string url, string form, UnityAction<string> action)
        {
            Debug.Log(url);
            UnityWebRequest www = UnityWebRequest.Post(url,form);
            
            www.SetRequestHeader("Content-Type", "application/json"); ;
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(form);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.chunkedTransfer = false;

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error + " "+ www.downloadHandler.text);
            }
            action(www.downloadHandler.text);
        }


        IEnumerator POST(string url, string form,Dictionary<string,string> dict, UnityAction<string> action)
        {
            Debug.Log(url);
            UnityWebRequest www = UnityWebRequest.Post(url, form);

            foreach(var obj in dict)
            {
                www.SetRequestHeader(obj.Key, obj.Value);
            }
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(form);
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.chunkedTransfer = false;

            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error + " " + www.downloadHandler.text);
            }
            action(www.downloadHandler.text);
        }*/
    }



    [System.Serializable]

    class API_RESPONSE<T>
    {
        public int status;
        public string message;
        public T data;
    }


    [System.Serializable]

    public class HTTP_BODY
    {
      //  public List<JSON_OBJECT> key;
     //   public List<string> value;
     public Dictionary<string,string> body;
        public HTTP_BODY()
        {
          //  key = new List<string>();
           // value = new List<string>();
        }

        public void AddValue(string key,string value)
        {
         //   this.key.Add(key);
          //  this.value.Add(value);
        }
    }

    public class JSON_OBJECT
    {
        public string key;
        public string value;
    }
}
