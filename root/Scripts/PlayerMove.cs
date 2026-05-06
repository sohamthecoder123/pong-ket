using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This handles the player's/bat's movement 
*/

public class PlayerMove : MonoBehaviour
{
    public float speed; //speed of player
    Transform player; //transform of player

    public float yConstraint; //constrains player in y axis

    public float y; //made it public so that the ball script can access it

    Vector3 initPos;

    Vector3 position; //position of player (to not write player.position all the time)

    private void Start()
    {
        player = GetComponent<Transform>(); //initialize player transform
    }

    private void Update()
    {
        position = player.position; //set position

        y = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime; //determines motion in y axis

        //y = Mathf.Clamp(y, -yConstraint, yConstraint); //constrain player speed???

        position += new Vector3(0, y, 0); //update position

        player.position = new Vector3(position.x, Mathf.Clamp(position.y, -yConstraint, yConstraint), 0); //set new position, with clamping
    }
}
