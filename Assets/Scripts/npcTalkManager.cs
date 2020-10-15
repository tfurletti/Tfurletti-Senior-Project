using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class npcTalkManager : MonoBehaviour
{

    public GameObject UItextBox;
    public Text dialogueText;
    public bool updateBox;

    /*
        NAME: Start
        SYNOPSIS:
        Start is called before the first frame update


        DESCRIPTION:
        Start is called before the first frame update


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start()
    {

    }

    /*
        NAME: Update
        SYNOPSIS:
        Gets the keyboard entry with the space button to open the npc to chracter dialog. 


        DESCRIPTION:
        This function holds the ui features to start talking dialogs with npc to character 
        interations with the space bar as the activator. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */
    void Update()
    {
        if(UItextBox.activeInHierarchy == true && Input.GetButtonDown("space")) {
            UItextBox.SetActive(false);


        }
        
        else if ((updateBox && Input.GetButtonDown("space"))) {


            UItextBox.SetActive(true);

        }
    }

    /*
        NAME: OpenBox
        SYNOPSIS:
        Opens the UI box and enters the text that will go inside it when npc to player 
        interations. 


        DESCRIPTION:
        This function opens the text box that the player will see in the ui and fills it
        with text. It does this by setting the UI objects that are already create active. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void OpenBox(string inputText) {

        updateBox = true;
        UItextBox.SetActive(true);

        dialogueText.text = inputText;
    }
}
