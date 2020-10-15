using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject followTarget;
    private Vector3 targetPosition;
    public float c_moveSpeed;

    private static bool camExists;

    // Start is called before the first frame update

    /*
        NAME: Start
        SYNOPSIS:
        Controls the camera object to follow the player


        DESCRIPTION:
        Controls the camera object to follow the player


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */
    void Start()
    {
        if (!camExists) {
            camExists = true;

            // stop player from being destroyed on zone change
            DontDestroyOnLoad(transform.gameObject);

        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame

    /*
        NAME: Update
        SYNOPSIS:
        Gets the position of the camera and the player and makes sure that the camera 
        position is always on the player. 


        DESCRIPTION:
        Gets the position of the camera and the player and makes sure that the camera 
        position is always on the player. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {

        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, c_moveSpeed * Time.deltaTime);


    }
}
