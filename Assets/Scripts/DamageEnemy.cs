using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{

    public int damageGivenToEnemy;
    public GameObject DamageSplash;
    public Transform swordPoint;
    public GameObject damageNumber;

    private PlayerStatInfo playerStats;
    private int playerCurrentDamage;

    // 

    /*
        NAME: Start
        SYNOPSIS:
        Start is called before the first frame update


        DESCRIPTION:
        Start is called before the first frame update
        Gets the players stats from the player object and saves them for use. 


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

    // Update is called once per frame


    /*
        NAME: update
        SYNOPSIS:
        included in all unity classes


        DESCRIPTION:
        included in all unity classes. 


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
        NAME: OnTriggerEnter2D
        SYNOPSIS:
        used for 2D collider


        DESCRIPTION:
        If the damage trigger is hit, you use the things below to indicate that the damage is to an enemy. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */
    void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Enemy") {

            playerCurrentDamage = damageGivenToEnemy + playerStats.playerCurrentAtt;

            // used to indicate damage to enemy
            other.gameObject.GetComponent<EnemyHealthInformation>().DamageEnemy(playerCurrentDamage);
            Instantiate(DamageSplash, swordPoint.position, swordPoint.rotation);

            // quaternion 4 value indicator for rotation and euler allows it to take in a Vector3
            var clone = (GameObject) Instantiate(damageNumber, swordPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumberIndicator>().damageTotal = playerCurrentDamage;
        }

    }

}
