using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MotherStates
{
    Baby_is_Crying,
    PLAYER_GET_AHOLD,
    GUIDE_UI_POP_UP,
    GUIDE_UI_POP_UP2,
    Player_Movement,
    POLICE_OFFICER_DEATH_CUTSCENE,
    TakingAnimation,
    GUIDE_GUN_PICK_UP_ADD_IN_INVENTORY,
    PICK_UP_GUN,
    KILL_Zombies_EAT_A_BODY,
    KILL_ZOMBIE_PICK_UP_FLASHLIGHT,
    Kill_ZOMBIE_POOL2,
    POLICE_SATION_CUTSCENE,
    ZOMBIES_SPWAN_AROUND_Police_staion,
    Reached_police_station
}

public enum PoliceStationStates
{
    START,
    FIND_POLICE_CHEIF,
    STAIRWAYS_CUT_SCENE,
    ELECTRONIC_CUTSCENE,
    CUTSCENE_FINSH,


    PLAYER_FIX_WIRE_CUT_SCENE,
    PLAYER_HEAR_GROAN,

    POLICE_OFFICER_HELP_CUT_SCENE,
    POLICE_OFFICE_TURNING_CUT_SCENE,

    PLAYER_WALK_DOWN_CORRIDOR,

    OBJECTIVE_FIND_SCREDRIVER,

    OBJECTIVE_FIND_KEYCARD,

    ZOMBIES_SPWAN,

    //BATTLES_ZOMBIE_POLICE_OFFICER_CUTSCENE,
    //CAGES_CRIMINAL_TRAPPED_CUTSCENE,
    //CRIMINALONE_STORYTELLING_CUTSCENE,
    //OPEN_DESK_FIND_SCREWDRIVER_CUTSCENE,
    //ZOMBIES_APPROACHING_SOUND_CUTSCENE,
    //DECISION_FREE_CRIMINAL_FACE_HORD_OF_ZOMBIES,
    //FACE_HORD_OF_ZOMBIES,
    //MOVE_TO_OTHER_STAIRCASE,
    FIX_KEYCARD_READER_CUTSCENE,
    FIX_KEYCARD_READER_OBJECTIVE,
    
    ZOMBIES_SPAWNER_ON,
    MILIPEDES_SPWANER,




    GO_TO_JYM_AREA,
    PLAYER_ENTER_GYM_AREA,


    PLAYER_ENTER_WORKSTATION_HALL,
    CHIEF_OFFICE_CUTSCENE,

    CHIEF_OFFICE_CUTSCENE_FINSH,

    PLAYER_ENTER_CHIEF_OFFICE,


   WEAPON_ARTISAN,
   WEAPON_ARTISAN_CUTSCENE_FINSH, 
   
   PLAYER_GO_GROUND_FLOOR,
        
    PLAYER_MOVEMENT_TO_POLICE_LOOKER,
    PLAYER_MOVE_TO_POLICE_CHIEF,
    AN_INJURED_COP_FIGHT_WITH_PLAYER,
    CUTSCENE_DIALOGUE_BETWEEN_PLAYER_ARTISAN,
    OBJECTIVE_ESCAPE_WITH_WEAPON_ARTISAN,
    WEAPON_ARTISIAN_HEALTH,
    LIGHT_FLICKER_GLOOMIER,
    EQUIP_WAEPON_ARTISIAN_WITH_LIGHT,
    ATTACK_OF_ZOOMBIEST,
    PLAYER_HELP_WAEPON_ARTISIAN,
    PLAYER_DOWNSTAIR_MOVEMENT,
    ATTACK_OF_ZOOMBIEST_DOWNSTAIR,
    WEAPON_ARTIST_SUGGESTION,
    OBJECTIVE_ESCAPE_THROUG_POLICE_STATION,
    PLAYER_HELP_WEAPON_ARTISIAN,
    DIRECT_THE_PLAYER_PASS_BY_CAGES,
    IF_PLAYER_HELP_PREVIOUSLY_TO_RUN_CRIMINALS,
    IF_PLAYER_PREVIOUSLY_LEFT_CRIMINALS,
    WEAPON_ARTISIAN_GIVE_YOU_LAST_SPARE,
    PLAYER_AND_WEAPON_ARTISIAN_MOVEMENT_ELECTRONICGATE,
    WEAPON_ARTIST_PUNCHES_GATE,
    FINAL_ESCAPE_OUTSIDE,
    FINAL_DIALOGUE_CUTSCENE,
    FINISH
}


public enum IndustrialAreaStates
{
    //SCENE 12
    PLAYER_HEADS_EAST,
    KILL_TWO_ZOMBIE,
    FIND_AN_ANTIDOTE,
    PLAYER_REACHED_GATE,
    FORKLIFT_CUTSCENE,
    PLAYER_CONTROLS_AIM_SHOW,
    ZOMBIE_SPWANING_AROUND_VECHILE,
    //SCENE 13
    ONE_ZOMBIE_DROPE_BROWN_SHOE,
    OPEN_MAP_FIND_CELL_TOWER,
    CUTSCENE_FINSH,
    ROUTE_BLOCKED,
    //SCENE 14
    KEEPER_ZOMBIE_SPWAN,
    PLAYER_FIND_MOTHER_DOGTAG,
    PLAYER_GETS_NFT_WEAPON_UPGARDE,
    // SCENE 15
    A_SPIDER_TOWARDS_PLAYER,
    COUTSCENE_GROUP_SPIDER_CLOSE_FROM_EVERY_DIRECTION,
    // SCENE 16
    PLAYER_SHOOT_WATER_TOWER_FOR_WASH_SPIDER_AWAY,
    //SCENE 17
    PLAYER_CLIMB_ON_TOP_LADDER,
    LID_BURSTA_OPEN_SPILLING_PLAYER_TO_FLOOR,
    PLAYER_PICK_AMMO,
    BESIEGED_BY_BATS_PLAYER_SHOOT,
    PLAYER_REACHED_THE_TOP_OF_TOWER,
    GPS_TRACKER_COMES_ONLINE,
    //SCENE 18
    PLAYER_BACK_DOWN_THE_TOWER,
    ZOMBIE_SPWAN_AROUND_TRAIN,
    PLAYER_REACHED_WAREHOUSE,
    PLAYER_FIGHT_THE_ZOMBIES,
    WAREHOUSE_END_FIND_ROTMAN,
    //SCENE 19
    CUT_SCENE_PLAYER_TALKING_WITH_ROTMAN,
    PLAYER_FIGHT_WITH_ROTMAN,
    PLAYER_KILL_ALPHA_bOSS_USE_CRANE,
    ALPHA_BOS_DROPE_RARE_NFT,
    //SCENE 20
    PLAYER_TOWARD_GPS_SIGNAL,
    ZOMBIES_SPWAN_FROM_POWER_UNIT,
    CUTSCENE_PLAYER_TALKING_EDWARDS,
}

public enum LabStates
{

}

