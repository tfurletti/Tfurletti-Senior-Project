using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartGameButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler 
    
    {

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

    void Start()
    {
        
    }

    // Update is called once per frame


    /*
        NAME: Update
        SYNOPSIS:
        Start is called before the first frame update


        DESCRIPTION:
        Calls the replace image and put image back functions in order to get the highlighted effect
        when the player is hovering over the buttons. This is used to indicate that the player is going
        to hit the correct button. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {
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
        This function is used to get the input from the mouse that the player is hovering over
        to click the start button to start the game from the beggining without a load game state. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene("StartTown");

    }


    /*
        NAME: OnPointerEnter
        SYNOPSIS:
        


        DESCRIPTION:
        This is used to detect when the player is hovering the mouse over the 
        start button to highlight the button for click verification. 


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
