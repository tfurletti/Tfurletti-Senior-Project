using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCmovement : MonoBehaviour
{

    public float npcMovespeed;
    public bool isMoving;
    public float moveTime;
    public float idleTime;
    public Collider2D npcMovearea;

    private float moveCounter;
    private float idleCounter;
    private int moveDirection;
    private Vector2 minArea;
    private Vector2 maxArea;
    private bool inArea;
    private Rigidbody2D npcRigid;

    // 


    /*
        NAME: Start
        SYNOPSIS:
        Gets the initial NPC movement start


        DESCRIPTION:
        This function is used to get the initial NPC movement by picking a starting position,
        setting the min and max area that the npc can move, and gets moving and idle counters to 
        simulate real movement. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Start()
    {
        npcRigid = GetComponent<Rigidbody2D>();

        moveCounter = moveTime;
        idleCounter = idleTime;

        DirectionDecider();

        //npc area bound set
        if (npcMovearea != null) {

            minArea = npcMovearea.bounds.min;
            maxArea = npcMovearea.bounds.max;

            inArea = true;
        }

    }

    // 


    /*
        NAME: Update
        SYNOPSIS:
        Gets each axis position that the npc can move and makes the move. 


        DESCRIPTION:
        This function is used to pick a position that the npc can move, the speed in which that it moves,
        sets the moving and idle counter times, and also calls the direction decider to pick a random direction.


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {

        if(isMoving) {

            moveCounter -= Time.deltaTime;

            // use rigid body and the direction decider to move npc in the correct direction
            switch(moveDirection) {

                case 0:
                    npcRigid.velocity = new Vector2(0, npcMovespeed);

                    // if npc goes out of bounds stop moving
                    if(npcMovearea && transform.position.y > maxArea.y) {

                        isMoving = false;
                        idleCounter = idleTime;
                    }
                    break;

                case 1:
                    npcRigid.velocity = new Vector2(npcMovespeed, 0);

                    // if npc goes out of bounds stop moving
                    if (npcMovearea && transform.position.x > maxArea.x) {

                        isMoving = false;
                        idleCounter = idleTime;
                    }
                    break;

                case 2:
                    npcRigid.velocity = new Vector2(0, -npcMovespeed);

                    // if npc goes out of bounds stop moving
                    if (npcMovearea && transform.position.y < minArea.y) {

                        isMoving = false;
                        idleCounter = idleTime;
                    }
                    break;

                case 3:
                    npcRigid.velocity = new Vector2(-npcMovespeed, 0);

                    // if npc goes out of bounds stop moving
                    if (npcMovearea && transform.position.x < minArea.x) {

                        isMoving = false;
                        idleCounter = idleTime;
                    }
                    break;

            }

            // when is done with move time, switch to idle time
            if (moveCounter < 0) {

                isMoving = false;
                idleCounter = idleTime;
            }

        }
        else {

            idleCounter -= Time.deltaTime;

            npcRigid.velocity = Vector2.zero;

            // When the npc idle counter becomes less then zero decide the new direction for the npc ot move
            if(idleCounter < 0) {

                DirectionDecider();
            }
        }

    }

    // 


    /*
        NAME: DirectionDecider
        SYNOPSIS:
        This function picks a direction for the npc to move in using built in unity randomizer. 


        DESCRIPTION:
        This function is used to simulate random movement of npc objects so that the enemies or npc people
        move in realistic or "game like" movements. This also starts a moving counter like as above. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    public void DirectionDecider() {

        moveDirection = UnityEngine.Random.Range(0, 4);
        isMoving = true;
        moveCounter = moveTime;
    }
}
