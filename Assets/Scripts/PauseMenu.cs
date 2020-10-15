using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update


    /*
        NAME: Start
        SYNOPSIS:


        DESCRIPTION:
        Required in unity as a generic function in the class.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start()
    {
        
    }

    // Update is called once per frame

    /*
        NAME: Update
        SYNOPSIS:
      


        DESCRIPTION:
        This functions gets the key input for the escape button to access and de-access the pause 
        menu. This is a key function as it sets the player inactive when the pause menu is open
        and reactives the player when the pause menu is closed. Also the pause menu allows for a 
        save game, exit game and resume game buttons. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {

        // pause menu
        if (Input.GetButtonDown("Pause")) {


            this.gameObject.SetActive(false);
            player.SetActive(true);
        }

    }
}
