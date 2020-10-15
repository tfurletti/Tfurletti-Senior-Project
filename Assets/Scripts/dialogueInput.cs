using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueInput : MonoBehaviour
{

    public string d_Text;

    private npcTalkManager npc1Manager;

    /*
        NAME: Start
        SYNOPSIS:
        Gets the npc object type


        DESCRIPTION:
        This function gets the NPC Object type


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */
    void Start()
    {
        npc1Manager = FindObjectOfType<npcTalkManager>();
    }

    /*
        NAME: update
        SYNOPSIS:
        included in all unity classes


        DESCRIPTION:
        included in all unity classes


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */
    void Update()
    {
        
    }

    /*
    NAME: OntriggerStay2D
    SYNOPSIS:
    If Player is in the collider zone for npc and press space dialogue box shows up


    DESCRIPTION:
    If Player is in the collider zone for npc and press space dialogue box shows up


    RETURNS:

    AUTHOR:
        Thomas Furletti
    DATE:
        07/08/2020
    */
    // 
    void OnTriggerStay2D(Collider2D inZone) {

        if (inZone.gameObject.name == "Player") {

            if (Input.GetButtonDown("space")) {

                npc1Manager.OpenBox(d_Text);
            }

        }
    }


    /*
    NAME: OnTriggerEnter2D
    SYNOPSIS:



    DESCRIPTION:
    If the player enters the collider2D The boolean value of update box is set to true
    meaning that on pressing space the text box will have hit all the requirements to be 
    opened.


    RETURNS:

    AUTHOR:
        Thomas Furletti
    DATE:
        07/08/2020
    */
    // 

    void OnTriggerEnter2D(Collider2D inZone) {

        if (inZone.gameObject.name == "Player") {

            inZone.gameObject.GetComponent<npcTalkManager>().updateBox = true;



        }
    }


    /*
    NAME: OnTriggerExit2D
    SYNOPSIS:



    DESCRIPTION:
    This is the same as the previous function, but checks when the player leaves to collider2D zone.
    Meaning that the requirements for the text box or dialog box to be opened are not met. 


    RETURNS:

    AUTHOR:
        Thomas Furletti
    DATE:
        07/08/2020
    */
    // 

    void OnTriggerExit2D(Collider2D inZone) {
        if (inZone.gameObject.name == "Player") {

            inZone.gameObject.GetComponent<npcTalkManager>().updateBox = false;



        }

    }


            //if (inZone.gameObject.name == "Player") {

            //   if (Input.GetKeyUp(KeyCode.Space)) {

            //      npc1Manager.OpenBox(d_Text);
            //  }
            // }
}
       

