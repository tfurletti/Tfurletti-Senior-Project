using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadGameButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {
    public Texture highlight;
    public Texture original;

    private bool mouseover = false;


    // Start is called before the first frame update


    /*
        NAME: Start
        SYNOPSIS:
        


        DESCRIPTION:
        Start is called before the first frame update


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start() {

    }

    // 


    /*
        NAME: Update
        SYNOPSIS:
        


        DESCRIPTION:
        This update function is used to call the replace and putimageback functions. 
        This is needed because it indicated in real time that the player is hovering over
        the load button on the main menu. When the load button is hovered it is then highlighted
        by replacing the original image with a lighter version so that the player can see were
        they are about to click so there is less room for error. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update() {
        if (mouseover) {
            replaceImage();
        }

        if (!mouseover) {
            putImageBack();
        }
    }


    /*
        NAME: OnPointerClick
        SYNOPSIS:
        


        DESCRIPTION:
        This function is used to load a previously saved game state so that the player can continue were they left off. 
        This is important because the player does not have to start from the begging of game everytime they
        want to play. This function is not currently working. In the function I removed the bad code and have 
        sudo code with how I would do it. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void OnPointerClick(PointerEventData eventData) {
         SceneManager.LoadScene("Load State");

        // Click the button 

        // Get the saved game file and parce it in.

        // Use the game file that was parced into load the saved scene that was the last 
        // player position and area.

        // Saves positions of npcs and enemies / bosses

        // 




    }


    /*
        NAME: OnPointerEnter
        SYNOPSIS:
        


        DESCRIPTION:
        This is used to detect when the player is hovering the mouse over the 
        Load button to highlight the button for click verification. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void OnPointerEnter(PointerEventData eventData) {
        mouseover = true;
        Debug.Log("Mouse enter");
    }


    /*
        NAME: OnPointerExit
        SYNOPSIS:
        


        DESCRIPTION:
        This is used to deactive the highlighted button when the player moves the mouse
        away from the button so that it goes back to the default button look. This indicates
        that the button is not being hovered so it can not be clicked on accident. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void OnPointerExit(PointerEventData eventData) {
        mouseover = false;
        Debug.Log("Mouse exit");
    }


    /*
        NAME: replaceImage
        SYNOPSIS:
       


        DESCRIPTION:
        This function is used to grab the raw image file and replace it with the
        highlighted image file to get the effect when mouseing over the button. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void replaceImage() {

        RawImage current = this.gameObject.GetComponent<RawImage>();
        current.texture = highlight;

    }


    /*
        NAME: putImageBack
        SYNOPSIS:
        


        DESCRIPTION:
        This function is used to put the stock image back after the button is no longer being hovered
        so that it goes back to the default image. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void putImageBack() {

        RawImage current = this.gameObject.GetComponent<RawImage>();
        current.texture = original;

    }
}
