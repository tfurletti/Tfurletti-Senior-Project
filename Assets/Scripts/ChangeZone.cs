using System.Collections;
using System.Collections.Generic;
//using System.Runtime.Hosting;
using UnityEngine;

public class ChangeZone : MonoBehaviour
{

    private PlayerMovement myPlayer;

    public string loadZone;
    public string exitZone;



    // 

    /*
        NAME: Start
        SYNOPSIS: 
        Start is called before the first frame update


        DESCRIPTION:
        Start is called before the first frame update
        Gets the player object when entering new zones. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */
    void Start()
    {
        myPlayer = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame


    /*
        NAME: update
        SYNOPSIS:
        included in all unity classes


        DESCRIPTION:
        included in all unity classes. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {
        
    }

    // 

    /*
        NAME: OnTriggerEnter2D
        SYNOPSIS:
        Loads the player into the new Zone. 


        DESCRIPTION:
        Loads the player into the new zone. This happens when a player walks onto a tile or 
        area that is set to switch zones. These are not visible as they are hidden game objects
        that are colliders, but are indicated with visual paths that lead off the current scene.
        When the player walks onto them they are then switched to the new zone.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.name == "Player") {
            Application.LoadLevel(loadZone);
            myPlayer.startZone = exitZone;
        }
    }



}
