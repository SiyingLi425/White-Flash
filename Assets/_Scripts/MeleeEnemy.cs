using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController
{
    public override void moveEnemy(float speed, int direction)
    {
        //GetComponent<Rigidbody2D>().position += new Vector2(speedX, 0.0f);
        if(direction == 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
        }
        



    }

}

