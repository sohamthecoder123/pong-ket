using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This handles how the bat is to function 
*/
public class BatScript : MonoBehaviour
{
    //bools to determine state of bat
    public bool defensive, power;
    public bool middle;

    //time for power shots
    public float powerTime;
    float timer;

    //player input
    void PlayerInput()
    {
        //defensive
        defensive = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        //power
        Power();

        //neither of the above two (ie middle)
        middle = !(defensive || power);
    }

    //power
    void Power()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            timer = Time.time + powerTime; //Start timer when space is hit
        }

        //use timer to see whether the shot is powered or not
        if(Time.time <= timer)
        {
            power = true;
        }
        else
        {
            power = false;
        }
    }

    private void Start()
    {
        power = false; //initialize value of power bool
    }

    private void Update()
    {
        PlayerInput(); //get player input every frame
    }

}
