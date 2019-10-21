/*
 White Flash
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 21/10/2019
 Description: Deals with boss, and setting goal to active when boss dies
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    public int bossLives = 3;
    public GameObject bossExplode;
    public GameObject goal;
   
    public override void Start()
    {
        base.Start();
    }
    /// <summary>
    /// moves the Boss 
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="direction"></param>
    public override void moveEnemy(float speed, int direction)
    {
        if (direction == 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
        }
    }

    /// <summary>
    /// destroy boss and makes goal active
    /// </summary>
    public override void death()
    {
        if(bossLives > 1)
        {
            bossLives--;
        }else
        { 
            notDead = false;
            gameController.bossDefeat();
            Instantiate(bossExplode, this.transform.position, this.transform.rotation);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 5.0f);
        }

    }
}
