using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Mir.Responses;

namespace Mir
{
    public class MenuManager : Singleton<MenuManager>
    {

        public GameObject loadingScreen;
        [Header("API Loading")]
        [SerializeField]
        private GameObject apiLoadingScree;
    
        [SerializeField]
        private List<GameObject> allMenus;
        public PopUpController _popupController;

        private void OnEnable()
        {
           
        }

        // Enable API Loading Scene
        public void EnableAPILoading(bool val)
        {
            apiLoadingScree.SetActive(val);
        }

        public void LoadScene(GameObject currentScreen,GameObject nextScreen,string levelName)
        {
            loadingScreen.SetActive(true);
            currentScreen.SetActive(false);
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
            operation.completed += (AsyncOperation c) =>
              {
                  if (c.isDone)
                  {
                      loadingScreen.SetActive(false);
                      if (nextScreen != null)
                      {
                          nextScreen.SetActive(true);
                      }
                  }
              };
        }

        public void OpenLoading(bool value)
        {
           //loadingScreen.SetActive(value);
        }

        public void CloseAllMenus()
        {
            foreach (GameObject g in allMenus)
            {
                g.SetActive(false);
            }
        }


        //Open One Menu Screen at one time ...
        public void OpenScreen(String screenName)
        {
            for (int i = 0; i < allMenus.Count; i++) { allMenus[i].SetActive(screenName == allMenus[i].name ? true : false); }
        }

        public void OpenScreen(GameObject loginScreen)
        {
            GameObject l = allMenus.Find(x => x == loginScreen);
            Debug.Log("Menu Opend " + l.gameObject.name);
            CloseAllMenus();
            l.SetActive(true);
         
        }
        public void OpenPopup(GameObject screen, bool status = true)
        {
            GameObject l = allMenus.Find(x => x == screen);
            l.SetActive(status);
        }
        public void InstantiateScreen()
        {

        }
    }
}