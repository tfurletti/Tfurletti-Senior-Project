using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class DamageNumberIndicator : MonoBehaviour
{

    public float numberSpeed;
    public int damageTotal;
    public Text outputNumber;




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

    // Update is called once per frame


    /*
        NAME: update
        SYNOPSIS:
        included in all unity classes


        DESCRIPTION:
        included in all unity classes. Gets the damage total and sets the value
        also gets the position of the damage value


        RETURNS:

        AUTHOR:
            Thomas Furletti
        DATE:
            07/08/2020
        */

    void Update()
    {
        outputNumber.text = damageTotal.ToString();
        transform.position = new Vector3(transform.position.x, transform.position.y + (numberSpeed * Time.deltaTime), transform.position.z);
    }
}
