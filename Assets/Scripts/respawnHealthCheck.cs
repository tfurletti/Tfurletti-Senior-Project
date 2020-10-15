using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnHealthCheck : MonoBehaviour
{

    public GameObject[] player;
    public GameObject ThePlayer;

    // Start is called before the first frame update
    void Start()
    {

        ThePlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {

        player = GameObject.FindGameObjectsWithTag("Player");

        if (player.Length < 1) {
            ThePlayer.SetActive(true);
            ThePlayer.GetComponent<playerHealthInformation>().playerCurrentHp = 30;
        }


    }
}
