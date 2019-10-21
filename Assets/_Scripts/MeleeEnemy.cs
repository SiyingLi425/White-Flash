/*
 White Flash
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 21/10/2019
 Description: Deals with melee enemy, uses enemyController as abstract
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyController
{
    public override void moveEnemy(float speed, int direction)
    {
        //checks which direction to walk
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

