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
        goal = GameObject.FindGameObjectWithTag("Goal");
    }
    public override void moveEnemy(float speed, int direction)
    {
        //GetComponent<Rigidbody2D>().position += new Vector2(speedX, 0.0f);
        if (direction == 0)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed);
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed);
        }


    }
    public override void death()
    {
        if(bossLives > 1)
        {
            bossLives--;
        }else
        { 
            notDead = false;
            goal.SetActive(true);
            Instantiate(bossExplode, this.transform.position, this.transform.rotation);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 5.0f);
        }

    }
}
