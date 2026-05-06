using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This manages the fielder's zone 
*/

public class FielderZoneScript : MonoBehaviour
{
    public bool isInZone; // the bool to store info regarding whether the ball is in the zone or not

    //if ball enters zone, set the above bool to true
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            isInZone = true;
        }
    }

    //if ball leaves zone, set above bool to false
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            isInZone = false;
        }
    }
}
