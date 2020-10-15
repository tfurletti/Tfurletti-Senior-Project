using System.Collections;
using System.Collections.Generic;
//using System.Media;
using UnityEngine.UI;
using UnityEngine;

public class EnemyHealthInformation : MonoBehaviour
{
    private PlayerStatInfo playerStats;

    public int MaxHp;
    public int CurrentHp;
    public int enemyExpVal;
    public RectTransform HealthBar;

    // 


    /*
        NAME: Start
        SYNOPSIS:
        Gets the player current hp and stats on start.


        DESCRIPTION:
        This function is used for constant tracking of the player stats and health. This
        is needed because if you do not keep track of these stats the player will have no
        point in leveling up. This is also for the enemy and how much damage they will take.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start() {
        CurrentHp = MaxHp;

        playerStats = FindObjectOfType<PlayerStatInfo>();

    }

    // 


    /*
        NAME: Update
        SYNOPSIS:
        Checks if the enemy health is below or equal to zero. 



        DESCRIPTION:
        If the enemy health gets below zero they are destroyed which will also reward the player with 
        experience points to level the player up.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update() {

        if (HealthBar != null) {
            HealthBar.sizeDelta = new Vector2((CurrentHp / MaxHp) * 200, HealthBar.sizeDelta.y);
        }

        if (CurrentHp <= 0) {

            Destroy(gameObject);
            playerStats.IncreaseExp(enemyExpVal);
        }
    }

    // 


    /*
        NAME: DamageEnemy
        SYNOPSIS:
        Takes the current hp of the enemy and lowers it depending on the damage modifiers that the player has.


        DESCRIPTION:
        The damage modifiers that the player has can be effected by the weapon that the player is holding,
        the level of the player, and character buffs that would increase the players stats. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void DamageEnemy(int damageGiven) {
        CurrentHp -= damageGiven;
    }

    // 


    /*
        NAME: SetMaxHealth
        SYNOPSIS:
        Sets the enemy max health on when they are created.


        DESCRIPTION:
        This function is used to make sure that the enemies are getting the correct max health. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void SetMaxHealth() {
        CurrentHp = MaxHp;
    }
}
