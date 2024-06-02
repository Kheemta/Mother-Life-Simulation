using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mir;
using TMPro;
// these are gameplay scripts
public class GamePlayController : StateMachineManager<MotherStates>
{
    [SerializeField]
    private MotherGamePlayValidStates _validStates;

    [SerializeField]
    private MotherStates _currentState;
    [Header("Menu")]
    [SerializeField]
    private GameObject Winpanel;
    [SerializeField]
    private TMP_Text progress_text;
    private GameObject PausePanel;
    public MotherStates CurrentState 
    {
        get => _currentState;
    }
    
  //  public Chapter1ExteriorStates nextState;


     
    private void OnEnable()
    {
        DracoArts.Instance.gameManager.Subscribe(Mir.EventType.GameStateEvent, "GameStateChange", GameStateChangeEvent);
        HandleCutScene(_currentState);
        HandleMenus(_currentState);
        HandleGameObjects(_currentState);
        HandleData(_currentState);
       
    }


    private void OnDisable()
    {
        DracoArts.Instance.gameManager.UnSubscribe(Mir.EventType.GameStateEvent, "GameStateChange", GameStateChangeEvent);
    }

    public void GameStateChangeEvent(string data)
    {
        Debug.Log("State = " + data);
        if (data == "PLAYER_GET_AHOLD")
        {
            setCurrentState(MotherStates.PLAYER_GET_AHOLD);
        }
        else if (data == "GUIDE_UI_POP_UP")
        {
            setCurrentState(MotherStates.GUIDE_UI_POP_UP);
        }
        else if (data == "GUIDE_UI_POP_UP2")

        {


            setCurrentState(MotherStates.GUIDE_UI_POP_UP2);
        }
        else if (data == "Player_Movement")

        {
            setCurrentState(MotherStates.Player_Movement);
        }
        else if (data == "POLICE_OFFICER_DEATH_CUTSCENE")
        {


            setCurrentState(MotherStates.POLICE_OFFICER_DEATH_CUTSCENE);
        }

        else if (data == "TakingAnimation")
        {



            setCurrentState(MotherStates.TakingAnimation);
        }

        else if (data == "GUIDE_GUN_PICK_UP_ADD_IN_INVENTORY")
        {



            setCurrentState(MotherStates.GUIDE_GUN_PICK_UP_ADD_IN_INVENTORY);
        }


        else if (data == "PICK_UP_GUN")
        {
            Debug.Log(data);
           
            setCurrentState(MotherStates.PICK_UP_GUN);
        }

        else if (data == "KILL_Zombies_EAT_A_BODY")
        {


            setCurrentState(MotherStates.KILL_Zombies_EAT_A_BODY);
        }


        else if (data == "KILL_ZOMBIE_PICK_UP_FLASHLIGHT")
        {

            setCurrentState(MotherStates.KILL_ZOMBIE_PICK_UP_FLASHLIGHT);
        }

        // else if (data == "Kill_ZOMBIE_POOL2")
        // {


        //     setCurrentState(Chapter1ExteriorStates.Kill_ZOMBIE_POOL2);
        // }
        //  else if(data== "POLICE_SATION_CUTSCENE")
        // {

        //     setCurrentState(Chapter1ExteriorStates.POLICE_SATION_CUTSCENE);


        // }

        // else if(data== "ZOMBIES_SPWAN_AROUND_Police_staion")
        // {


        //     setCurrentState(Chapter1ExteriorStates.ZOMBIES_SPWAN_AROUND_Police_staion);

        // }

        // else if(data== "Reached_police_station")
        // {
        //     setCurrentState(Chapter1ExteriorStates.Reached_police_station);

        // }
    }






















    public override void setCurrentState(MotherStates nextState)
    {
        if(_validStates.isValidState(_currentState, nextState))
        {
            _currentState = nextState;
        }
        Debug.Log("Current State " + nextState.ToString());
        HandleMenus(_currentState);
        HandleGameObjects(_currentState);
        HandleData(_currentState);
        HandleCutScene(_currentState);
    }

    protected override void HandleMenus(MotherStates currentState)
    {
        switch (currentState)
         {
                case MotherStates.Baby_is_Crying:
                progress_text.text=" Baby is crying.Find the pacifier";
              
                break;

        //     case Chapter1ExteriorStates.PLAYER_GET_AHOLD:
                



                
        //         break;
        //     case Chapter1ExteriorStates.GUIDE_UI_POP_UP:
        //         UI_lookCamera.SetActive(true);
        //         _objectiveText.text = "Drag your finger area to move camera.";
        //         break;




        //     case Chapter1ExteriorStates.GUIDE_UI_POP_UP2:

        //         UI_lookCamera.SetActive(false);
        //         _openUItutorial.SetActive(false);
        //      _objectiveText.text = "Drag your finger For Player move.";
        //         UI_JoyStick.SetActive(true);

        //         break;
        //     case Chapter1ExteriorStates.Player_Movement:

        //         GameObject.Find("PLAYER").GetComponent<vShooterMeleeInput>().enabled = true;

        //         GameObject.Find("PLAYER").GetComponent<vThirdPersonController>().enabled = true;
        //         GameObject.Find("PLAYER").GetComponent<vLockOnShooter>().enabled = true;
        //         GameObject.Find("Inventory").GetComponent<vInventory>().enabled = true;
        //         thirdcamera.SetActive(true);






        //         jumbuton.SetActive(true);
        //         UI_JoyStick.SetActive(false);
        //         _openUItutorial.SetActive(false);
        //         UI_lookCamera.SetActive(false);
        //         _objectiveText.text =" Go To Police Officer";
              
                


        //         break;
        //     case Chapter1ExteriorStates.POLICE_OFFICER_DEATH_CUTSCENE:

                
        //         _objectiveText.text = "Talking with police chiefe";

        //         break;


        //     case Chapter1ExteriorStates.TakingAnimation:

        //         Debug.Log("Animation talking");



        //         break;
        //     case Chapter1ExteriorStates.GUIDE_GUN_PICK_UP_ADD_IN_INVENTORY:
        //         _objectiveText.text = "Pick_Up Gun Button";
        //         Gun_pick_Button.SetActive(true);

        //         break;
        //     case Chapter1ExteriorStates.Reached_police_station:

        //         Winpanel.SetActive(true);

        //         Glow.SetActive(false);


        //         break;



         }
    }

    public override void HandleGameObjects(MotherStates currentState)
    {
        // switch (currentState)
        // {
        //     case Chapter1ExteriorStates.Dazed_Crash_Cutscene:



        //        // GameObject.Find("vShooterMelee_NoInventory (1)").GetComponent<vShooterMeleeInput>().enabled = true;
               
        //        //GameObject.Find("vShooterMelee_NoInventory (1)").GetComponent<vThirdPersonController>().enabled = true;

        //         //thirdcamera.SetActive(false);
        //        // Contollfreak.SetActive(false);
        //        // cheifTrigger.SetActive(false);

        //         break;
        //     case Chapter1ExteriorStates.PLAYER_GET_AHOLD:
                
        //         break;

        //     case Chapter1ExteriorStates.POLICE_OFFICER_DEATH_CUTSCENE:

        //         thirdcamera.SetActive(false);
        //         Cutscene2.SetActive(true);


               



        //         break;

        //     case Chapter1ExteriorStates.TakingAnimation:

        //         Debug.Log("animation talking");
        //         break;




        //     case Chapter1ExteriorStates.GUIDE_GUN_PICK_UP_ADD_IN_INVENTORY:

        //         thirdcamera.SetActive(true);
        //         Cutscene2.SetActive(false);
        //         cheifTrigger.SetActive(false);
               

        //         break;

        //     case Chapter1ExteriorStates.PICK_UP_GUN:

        //         _objectiveText.text = "Gun_Fire_Button";
        //         GunTrigger.SetActive(false);
        //         Fire_Button.SetActive(true);
        //         Aming_Button.SetActive(true);
        //         Reload_Button.SetActive(true);


        //         break;
        //     case Chapter1ExteriorStates.KILL_Zombies_EAT_A_BODY:

        //         Zombies_eat_dethBody.SetActive(true);
        //         trigger_eat_body.SetActive(false);
        //         _objectiveText.text = "Kill Zombie";
        //         break;


        //     case Chapter1ExteriorStates.KILL_ZOMBIE_PICK_UP_FLASHLIGHT:
        //         ZombiesSpwan_1.SetActive(true);
        //         trigger_zomb_spwan1.SetActive(false);
              
        //         GameObject.Find("Object_st_13").GetComponent<Animator>().enabled = true;
        //         break;

        //     case Chapter1ExteriorStates.Kill_ZOMBIE_POOL2:


        //       // ZombiesSpwan_1.SetActive(false);
        //         //Zombie_spwan_pool2.SetActive(true);
        //         trigger_zomb_pool2.SetActive(false);
        //        // Invoke("zombpool2Deactive", 20);
        //         break;

        //     case Chapter1ExteriorStates.ZOMBIES_SPWAN_AROUND_Police_staion:



        //         thirdcamera.SetActive(true);
        //         Cutsene3.SetActive(false);
        //        // Zom_spwan_pool3.SetActive(true);
        //         triger_spwan_pool3.SetActive(false);
        //         //Invoke("zombpool3Deactive", 30);


        //         break;
                

        // }
    }

    protected override void HandleData(MotherStates currentState)
    {
        switch (currentState)
        {
            case MotherStates.Baby_is_Crying:

             break;
        }
    }

    protected override void HandleCutScene(MotherStates currentState)
    {
        switch (currentState)
        {
            case MotherStates.Baby_is_Crying:




                break;
            case MotherStates.POLICE_SATION_CUTSCENE:


           

                 
                break;
        }
    }


  public void Resume()
    {

       
       
    }

    public void Pause()
    {
       
    }

    public void Home()
    {

        
    }

 public void Restart()
    {
    }
    
  
}
