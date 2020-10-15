using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{

    private PlayerMovement player1;
    private CameraMovement camera1;

    public Vector2 playerDirection;

    public string loadName;

    // Start is called before the first frame update

    /*
        NAME: Start
        SYNOPSIS:
        Finds the player and tracks the position of the player


        DESCRIPTION:
        Gets the players position and the camerma position, tracks that position and makes
        sure that the camera is in the correct position.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */


    void Start()
    {
        // get current location of player
        player1 = FindObjectOfType<PlayerMovement>();

        if (player1.startZone == loadName) {
            player1.transform.position = transform.position;
            player1.lastMove = playerDirection;

            // get current location of camera
            camera1 = FindObjectOfType<CameraMovement>();
            camera1.transform.position = new Vector3(transform.position.x, transform.position.y, camera1.transform.position.z);
        }
    }

    // 


    /*
        NAME: Update
        SYNOPSIS:
        Update is called once per frame


        DESCRIPTION:
        Update is called once per frame


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {
        
    }
}
