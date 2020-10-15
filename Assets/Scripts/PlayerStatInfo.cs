using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatInfo : MonoBehaviour
{

    public int playerLevel;
    public int currentXP;
    public int[] levelUpThresh;

    public int[] healthStat;
    public int[] attackStat;
    public int[] defenseStat;
    public int playerCurrentHp;
    public int playerCurrentAtt;
    public int playerCurrentDef;

    private playerHealthInformation playerHp;


    // 

    /*
        NAME: Start
        SYNOPSIS:


        DESCRIPTION:
        Gets the players stats on start including the players hitPoints or life value.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start()
    {
        // player starting level 1 stats
        playerCurrentHp = healthStat[1];
        playerCurrentAtt = attackStat[1];
        playerCurrentDef = defenseStat[1];

        playerHp = FindObjectOfType<playerHealthInformation>();
    }

    // Update is called once per frame


    /*
        NAME: Update
        SYNOPSIS:


        DESCRIPTION:
        Checks the current level of the player


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {
        
        // check current level of player to see if it is possible to level up;
        if(currentXP >= levelUpThresh[playerLevel]) {
            PlayerLevelUp();
        }

    }

    // 


    /*
        NAME: IncreaseExp
        SYNOPSIS:



        DESCRIPTION:
        add experiece to player when experienced is gained by killing enemies etc.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void IncreaseExp(int addExperience) {
        currentXP += addExperience;
    }

    // 

    /*
        NAME: PlayerLevelUp
        SYNOPSIS:
        player level up stat information increase and modifiers


        DESCRIPTION:
        This function gets the current stats of the player based on there current level,
        then takes those numbers and increases them by the specific amount that is set. 
        To level up gets harder the higher level that the player is so it scales based
        on level. The stat increase also scale as the player levels up. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void PlayerLevelUp() {

        // on player levelup
        playerLevel++;

        // manage player hp on levelup
        playerCurrentHp = healthStat[playerLevel];
        playerHp.playerMaxHp = playerCurrentHp;
        playerHp.playerCurrentHp += playerCurrentHp - healthStat[playerLevel - 1];

        playerCurrentAtt = attackStat[playerLevel];
        playerCurrentDef = defenseStat[playerLevel];
    }
}
