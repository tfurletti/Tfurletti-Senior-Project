using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Animator anim;
    private bool playerMoving;
    private float currentMoveSpeed;
    private Rigidbody2D playerRigid;
    private static bool playerExists;
    private bool playerAttacking;
    private float attackingTimeCounter;

    public float moveSpeed;
    public float diagMoveSpeed;

    public Vector2 lastMove;
    public float attackingTime;
    public string startZone;

    public GameObject PauseMenu;


    // 

    /*
        NAME: Start
        SYNOPSIS:
        Gets the players start position and get the things needed for the animations to happen.


        DESCRIPTION:
        Gets the collider boxes and rigid body of the player to get the physical area that the player is in.
        Also, starts the animator function.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start() {
        anim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();

        if (!playerExists) {
            playerExists = true;

            // stop player from being destroyed on zone change
            DontDestroyOnLoad(transform.gameObject);

        }
        else {
            Destroy(gameObject);
        }
        
    }

    // 


    /*
        NAME: Update
        SYNOPSIS:
        This update function gets all the position changes of the character.
        It also gets the direction.
        Checks if the player is attacking.


        DESCRIPTION:
        This function gets all of the components and user entry to make teh character move,
        get the characters position, checks if the player is attacking, gets the speed of the character movement. 
        It also records the last position of the character so that it stays in the position that it was facing.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update() {

        // This if statement gets the button input from the pause menu so that it can he accessed whilst playing
        // the game in real time. This makes the players state set to inactive and sets the pause menu to active.
        if (Input.GetButtonDown("Pause")) {

            PauseMenu.SetActive(true);

            this.gameObject.SetActive(false);


        }


        playerMoving = false;

        // check if player is attacking
        if (!playerAttacking) {


            //Player movement
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {
                // transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerRigid.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, playerRigid.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }

            //Player movement
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {
                // transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerRigid.velocity = new Vector2(playerRigid.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            //Player movement
            if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f) {
                playerRigid.velocity = new Vector2(0f, playerRigid.velocity.y);
            }

            //Player movement
            if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f) {
                playerRigid.velocity = new Vector2(playerRigid.velocity.x, 0f);
            }

            // Get input and initiate attack from player
            if (Input.GetKeyDown(KeyCode.Return)) {

                attackingTimeCounter = attackingTime;
                playerAttacking = true;
                playerRigid.velocity = Vector2.zero;
                anim.SetBool("Attack", true);

            }

            // check if player is moving at an angle
            if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f) {
                currentMoveSpeed = moveSpeed * diagMoveSpeed;
            }
            else {
                currentMoveSpeed = moveSpeed;
            }
        }

        // Attack time counters and checkers
        if (attackingTimeCounter > 0) {
            attackingTimeCounter -= Time.deltaTime;

        }

        if (attackingTimeCounter <= 0) {
            playerAttacking = false;
            anim.SetBool("Attack", false);
        }

        // set animations
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

       
    }
}