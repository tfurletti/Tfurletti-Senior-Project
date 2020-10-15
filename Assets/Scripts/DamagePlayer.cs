using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int damageGiven;
    public GameObject damageNumber;

    private int playerCurrentDamage;
    private PlayerStatInfo playerStats;

    // Start is called before the first frame update

    /*
        NAME: start
        SYNOPSIS:
        finds the player object


        DESCRIPTION:
        Gets the player stats


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStatInfo>();
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

    // 

    /*
        NAME: OnCollisionEnter2D
        SYNOPSIS:
        get player health information and collision box



        DESCRIPTION:
        get player health information and collision box


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */
    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.name == "Player") {

            // player defense effect on damage taken
            playerCurrentDamage = damageGiven - playerStats.playerCurrentDef;
            if(playerCurrentDamage < 0) {

                playerCurrentDamage = 1;

            }

            other.gameObject.GetComponent<playerHealthInformation>().DamagePlayer(playerCurrentDamage);

            // quaternion 4 value indicator for rotation and euler allows it to take in a Vector3
            var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumberIndicator>().damageTotal = playerCurrentDamage;
        } 

    }

}
