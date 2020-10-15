using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOverTime : MonoBehaviour
{
    public float fadeTime;


    // 


    /*
        NAME: Start
        SYNOPSIS:
        Start is called before the first frame update


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

    // 


    /*
        NAME: Update
        SYNOPSIS:
        This update function fades objects on destrucion.


        DESCRIPTION:
        Used to fade objects out of view when either an enemy or player is destroyed. 


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {
        fadeTime -= Time.deltaTime;

        if(fadeTime <= 0) {
            Destroy(gameObject);
        }
    }
}
