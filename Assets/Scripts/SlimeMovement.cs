using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{

    private Rigidbody2D slimeRigid;
    private bool slimeMoving;
    private Vector3 slimeDirection;
    private float movingCounter;
    private float pauseCounter;
    private bool zoneReloading;
    private GameObject player1;

    public float slimeSpeed;
    public float timeMovePause;
    public float timeMoving;
    public float respawnTimer;


    /*
        NAME: Start
        SYNOPSIS:



        DESCRIPTION:
        This function gets the idle and moving timers for the slime enemies so that
        they can simulate real movement. It takes the Unity random built in function
        to get a value that the slimes will move for distance and time. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start()
    {
        slimeRigid = GetComponent<Rigidbody2D>();

        // Natural slime movement value generator
        pauseCounter = UnityEngine.Random.Range(timeMovePause * 0.75f, timeMovePause * 1.25f);
        movingCounter = UnityEngine.Random.Range(timeMoving * 0.75f, timeMoving * 1.25f);

        // Basic Movement values
        //pauseCounter = timeMovePause;
        //movingCounter = timeMoving;

    }

    // Update is called once per frame


    /*
        NAME: Update
        SYNOPSIS:



        DESCRIPTION:
        After the start function does the initial setup for the movement of the slimes, the
        update function then does the continuous movement of the slimes and the way that they interact
        with the player when the player is near by. It also handles a respawn timer and how the slimes
        respawn after they are destroyed by the player. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {
        
        // if slime is currently moving
        if (slimeMoving) {
            movingCounter -= Time.deltaTime;
            slimeRigid.velocity = slimeDirection;

            if(movingCounter < 0f) {

                slimeMoving = false;
                pauseCounter = UnityEngine.Random.Range(timeMovePause * 0.75f, timeMovePause * 1.25f);
            }
        }

        // if slime is not moving 
        else {
            pauseCounter -= Time.deltaTime;
            slimeRigid.velocity = Vector2.zero; 

            if(pauseCounter < 0f) {
                slimeMoving = true;
                movingCounter = UnityEngine.Random.Range(timeMoving * 0.75f, timeMoving * 1.25f);

                // slime direction decider on move
                slimeDirection = new Vector3(UnityEngine.Random.Range(-1f, 1f) * slimeSpeed, UnityEngine.Random.Range(-1f, 1f) * slimeSpeed, 0f);
            }
        }

        // Player Respawn timer and level reloader
        if (zoneReloading) {
            respawnTimer -= Time.deltaTime;

            if(respawnTimer < 0) {
                Application.LoadLevel(Application.loadedLevel);
                player1.SetActive(true);
            }
        }
    }

    // 


    /*
        NAME: OnCollisionEnter2D
        SYNOPSIS:
        Collision Checker with the slime and player


        DESCRIPTION:
        This function was for a specific enemy that was removed because it would kill the player right away
        and was game breaking so I removed it. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void OnCollisionEnter2D(Collision2D other) {

        // instantly kill player
        /* if (other.gameObject.name == "Player") {
            other.gameObject.SetActive(false);
            zoneReloading = true;
            player1 = other.gameObject;
        }
        */



    }

}
