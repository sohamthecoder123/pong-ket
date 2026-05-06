using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Handles the ball's motion, collision, reflection and scoring 
*/

public class BallMove : MonoBehaviour
{
    public float initSpeed; // initial speed of ball
    public float speedRandFactor; //controls randomness of speed

    float speed;

    Rigidbody2D rb; //rigidbody of ball

    public Transform wicket; //transform of wicket

    //has the ball been bowled?
    bool hasBowled = false;

    //has it tapped against ground? (used to determin spin)
    bool hasTapped = false;

    public bool isSpin; //can ball spin?

    //position of bowler
    Vector3 initPos;

    //velocity of ball at, surprisingly, the end of each frame
    Vector3 velocityAtEndOfFrame;

    //bounce back factor on the basis of state of bat
    public float mFactor, dFactor, pFactor;

    //factor affecting how much bat's speed should affect resultant speed of ball
    public float batFactorM, batFactorP;

    //game manager
    public GameManager gm;

    //state of the ball (determines no of runs scored)
    string state = "";

    //has the ball been hit by bat
    public bool isHit;

    //public float randScale;

    public AudioSource tapSource, wicketSource;

    private void Start()
    {
        //initalize rigidbody
        rb = GetComponent<Rigidbody2D>();
        //get initial position
        initPos = gameObject.transform.position;

        speed = initSpeed;
    }

    private void Update()
    {
        //direction of ball
        Vector3 direction = Vector3.zero; 

        //if there is no spin, direction of ball is straight to wicket
        if (!isSpin)
        {
            direction.x = (wicket.position - initPos).x;
            direction.y = (wicket.position - initPos).y + wicket.localScale.y * (-0.5f + Random.value);
        }

        else
        {
            Spin(); //spin the ball
        }


        //print(direction);

        //bowl the ball in first frame, then no longer add force
        if (!hasBowled)
        {
            rb.AddForce(direction * speed);
            gm.AddBalls(1);
        }

        hasBowled = true;

        //end of frame stuff
        velocityAtEndOfFrame = new Vector3(rb.velocity.x, -rb.velocity.y, 0f);

        speed = initSpeed + Random.value * speedRandFactor;
    }

    //collision handling (has to be done manually as bat's rb2d is kinematic)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.collider.tag; //i got tired of writing collision.collider.tag

        //if collided with bat
        if (tag == "Player") 
        {
            tapSource.Play();
            //set isHit to true
            isHit = true;

            BatScript bs = collision.gameObject.GetComponent<BatScript>(); //get the bat script ready, alfred
            PlayerMove pm = collision.gameObject.GetComponent<PlayerMove>(); //get player's script (for batspeed)

            Vector3 batRbVel = Vector3.up * pm.y; //the velocity of the bat

            //if bat is defensive
            if (bs.defensive)
            {
                rb.AddForce(-velocityAtEndOfFrame * dFactor);
                state = "slow";
            }

            //if bat is powered up
            else if (bs.power)
            {
                rb.AddForce(-velocityAtEndOfFrame * pFactor + batRbVel * batFactorP);
                state = "fast";
            }

            //if bat is neither
            else if (bs.middle)
            {
                rb.AddForce(-velocityAtEndOfFrame * mFactor + batRbVel * batFactorM);
                state = "medium";
            }
        }

        //if collided with wicket
        else if (tag == "Wicket")
        {
            wicketSource.Play();
            gm.AddWickets(1);

            Restart();

            //Destroy(gameObject);
        }

        //if collided with side
        else if (tag == "Sides")
        {
            if(state == "slow")
            {
                gm.AddRuns(1);
            }

            else if (state == "medium")
            {
                gm.AddRuns(2);
            }
            
            else if (state == "fast")
            {
                gm.AddRuns(4);
            }


            Restart();

            //Destroy(gameObject);

        }

        //if collided with front (long-off/long-on)
        else if (tag == "Front")
        {
            if (state == "slow")
            {
                gm.AddRuns(3);
            }

            else if (state == "medium")
            {
                gm.AddRuns(4);
            }

            else if (state == "fast")
            {
                gm.AddRuns(6);
            }

            Restart();

            //Destroy(gameObject);
        }
    }

    //spins the ball (wip)
    void Spin()
    {

    }

    //restart the ball (ie, next delivery once this one is dead)
    void Restart()
    {
        gameObject.transform.position = initPos;
        state = "";
        hasBowled = false;

        rb.velocity = Vector3.zero;
        isHit = false;
    }
}
