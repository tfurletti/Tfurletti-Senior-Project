using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class UIGameManager : MonoBehaviour
{

    public Slider HPbar;
    public Text HPtext;
    public playerHealthInformation currentPlayerHP;
    public Text LvlText;

    private PlayerStatInfo playerStats;
    private static bool UIExists;

    // Start is called before the first frame update


    /*
        NAME: Start
        SYNOPSIS:



        DESCRIPTION:
        This start function is used to load the current UI when the game is started.
        This handles if the UI does not currently exist it creates the handler if it does
        exist destroy the current gameObject. This is loads player stats that are displayed
        on the UI. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start()
    {
        if (!UIExists) {
            UIExists = true;

            // stop player from being destroyed on zone change
            DontDestroyOnLoad(transform.gameObject);

        } else {
            Destroy(gameObject);
        }

        playerStats = GetComponent<PlayerStatInfo>();
    }

    // Update is called once per frame


    /*
        NAME: Update
        SYNOPSIS:



        DESCRIPTION:
        This function gets the players current stats and health to be displayed on the 
        UI. You can see it on the top right of the screen were there is a working Health bar
        and some of the players stats including level. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {
        HPbar.maxValue = currentPlayerHP.playerMaxHp;
        HPbar.value = currentPlayerHP.playerCurrentHp;
        HPtext.text = "HP: " + currentPlayerHP.playerCurrentHp + "/" + currentPlayerHP.playerMaxHp;

        LvlText.text = "Lvl: " + playerStats.playerLevel;

    }
}
