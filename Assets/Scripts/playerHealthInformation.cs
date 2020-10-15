using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealthInformation : MonoBehaviour
{

    public int playerMaxHp;
    public int playerCurrentHp;

    public float flashDuration;

    private bool characterFlash;
    private float flashActiveTime;
    private SpriteRenderer playerImage;

    // 


    /*
        NAME: Start
        SYNOPSIS:
        Gets the players current health status and also create the visible render to the user.


        DESCRIPTION:
        This function is used to render the player object so that you can actually see it in the game once the
        game is actually started and collects the current health of the player. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start()
    {

        playerCurrentHp = playerMaxHp;

        playerImage = GetComponent<SpriteRenderer>();

    }

    // 


    /*
        NAME: Update
        SYNOPSIS:
        This update is used to destroy the player on death and animate taking damage.


        DESCRIPTION:
        Within this function if the player takes damage it will flash the player in and out.
        If the player is destroyed meaning that it it reaches zero hp the player disapears and 
        will be recreated or respawned back in the starting area in a different function. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {
        if(playerCurrentHp <= 0) {

            gameObject.SetActive(false);


        }

        // if player gets damaged flash character sprite opacity or alpha value in and out
        if(characterFlash) {

            if(flashActiveTime > flashDuration * 0.66f) {
                // get current player color and only change opacity or alpha value
                playerImage.color = new Color(playerImage.color.r, playerImage.color.g, playerImage.color.b, 0f);
            }
            else if(flashActiveTime > flashDuration * 0.33f) {
                playerImage.color = new Color(playerImage.color.r, playerImage.color.g, playerImage.color.b, 1f);
            }
            else if(flashActiveTime > 0f) {
                playerImage.color = new Color(playerImage.color.r, playerImage.color.g, playerImage.color.b, 0f);
            }
            else { 
                playerImage.color = new Color(playerImage.color.r, playerImage.color.g, playerImage.color.b, 1f);
                characterFlash = false;

            }
            flashActiveTime -= Time.deltaTime;
        }

    }

    // 


    /*
        NAME: DamagePlayer
        SYNOPSIS:
        Takes the players current hp and lowers it by the enemies damage modifier. 


        DESCRIPTION:
        This function is used to get the players current health and lower it by the enemies
        damage modifier that can change depending on player stats and monster stats. This 
        also starts the flashing animation when the player takes damage. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void DamagePlayer(int damageGiven) {
        playerCurrentHp = playerCurrentHp - damageGiven;

        characterFlash = true;
        flashActiveTime = flashDuration;

    }

    // 


    /*
        NAME: SetMaxHealth
        SYNOPSIS:
        Sets the players max health back to max


        DESCRIPTION:
        When a player is destroyed and respawns this function is used to set the players max health
         back to full health or back to the max amount because without the function the player would
         be created and destroyed infinitly. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void SetMaxHealth() {
        playerCurrentHp = playerMaxHp;
    }

}
