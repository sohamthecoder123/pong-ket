using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This handles the motion of the fielders 
*/

public class FielderMoveScript : MonoBehaviour
{
    public float speed; //speed of the fielder
    public FielderZoneScript fzs; //the script of this fielder's zone
    public Transform ball; //the ball
    BallMove bm; //the ball's movement script
    public Rigidbody2D rb; //fielder's rigidbody2D

    private void Start()
    {
        bm = ball.gameObject.GetComponent<BallMove>(); //initialize ballMove 
    }

    private void Update()
    {
        if (fzs.isInZone && bm.isHit) //if the ball is in this fielder's zone and has been hit by the bat
        {
            rb.velocity = (ball.position - gameObject.transform.position) * speed * Time.deltaTime; //chase the ball
        }

        else //if not
        {
            rb.velocity = Vector3.zero; //stop chasing the ball
        }
    }
}
