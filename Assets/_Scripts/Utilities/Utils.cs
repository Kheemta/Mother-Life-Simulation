using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using Mir;
using System.Linq;
using Mir.Core;
using UnityEngine.Networking;
using System.Threading.Tasks;
using UnityEngine.Events;

public class Utils : MonoBehaviour
{
   
    public static void DisableListofGameObject(List<GameObject> _list)
    {
        _list.ForEach(x => x.SetActive(false));
        _list[0].gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    //internal static void ListToString(object menmonic)
    //{
    //    throw new NotImplementedException();
    //}

    public static void ToggleGameObject(GameObject g,bool value)
    {
        g.SetActive(value);
    }

  

    public static string ListToString(List<string> list)
    {
       string result = "";
       List<string> temp = new List<string>(list);
       temp.ForEach(e => { result += e; });
       return result;
    }


    public static string TrimCharacter(string value,string c)
    {
        return value.Replace(c,"") ;
    }
    public static List<string> StringToList(string sentence,char split)
    {
        List<string> words = new List<string>(sentence.Split(split));
        return words;
    }

    public static List<string> ShuffleList(List<string> nemonicWords)
    {
       
        List<string> list = new List<string>(nemonicWords);

        for (var i = 0; i < list.Count; i++)
        {
            var Reverse = UnityEngine.Random.Range(0, list.Count);
            var temp = list[i];
            list[i] = list[Reverse];
            list[Reverse] = temp;
        }
        return list;

    }


    public static void CopyToClipBoard(string data)
    {
        TextEditor te = new TextEditor();
        te.text = data;
        te.SelectAll();
        te.Copy();
    }

    public static string PasteFromClipboard()
    {
        TextEditor _paste = new TextEditor();
        _paste.multiline = true;
        _paste.Paste();
        return _paste.text;
    }

   public static string GetTimeDuration(long startTime, long endTime)
    {
        DateTime start = DateTime.FromFileTimeUtc(startTime);
        //print(start);
        DateTime end = DateTime.FromFileTimeUtc(endTime);
        //print(end);
        TimeSpan temp = end - start;
   
        return string.Format("{0:00},{1:00}:{2:00}", temp.Hours, temp.Minutes, temp.Seconds);
    }

    public static void Log(string message)
    {
        if (Mir.DracoArts.Instance.isDevelopment)
        {
            print(message);
        }
    }

   

    public static IEnumerator GetTexture(string url, UnityAction<Texture2D> action)
    {
        UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
        uwr.SetRequestHeader("Accept-Encoding", "gzip, deflate, br");
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(uwr.error);
            action(null);
            // return null;
        }
        else
        {
            // Get downloaded asset bundle
            var texture = DownloadHandlerTexture.GetContent(uwr);
            action(texture);
            //  return texture;
        }
    }


   


} 