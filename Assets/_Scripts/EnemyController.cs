﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EnemyController : MonoBehaviour
{

    //Public Variables
    public float walkSpeed;
    public int attackSpeed;
   

    

    //Private Variables
    protected Animator enemyAnimator;
    protected Collider2D aggroRange, hitBox, playerCollider, attackRange;
    private GameObject aggroedPlayer;
    private PlayerController playerController;
    protected Vector2 target, playerPosition;
    protected int attackCoolDown;
    protected Transform enemyTransform;
    private Transform playerTransform;
    protected int direction = 0;
    protected bool notDead = true;
    protected GameController gameController;





    public Collider2D HitBox { get { return hitBox; } }

    // Start is called before the first frame update
    public virtual void Start()
    {
        aggroRange = GetComponent<CircleCollider2D>();
        attackRange = GetComponent<PolygonCollider2D>();
        hitBox = GetComponent<BoxCollider2D>();
        enemyTransform = GetComponent<Transform>();
        enemyAnimator = GetComponent<Animator>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        
    }

    // Update is called once per frame
    protected virtual void Update()
    { 
        aggroedPlayer = GameObject.FindGameObjectWithTag("Player");
        playerController = aggroedPlayer.GetComponent<PlayerController>();
        playerCollider = aggroedPlayer.GetComponent<PolygonCollider2D>();
        playerPosition = aggroedPlayer.GetComponent<Transform>().position;
        playerTransform = aggroedPlayer.GetComponent<Transform>();


        if (playerCollider.IsTouching(attackRange) && attackCoolDown == 0)
        {
            attack();
        }

        if (playerCollider.IsTouching(aggroRange))
        {
            target = playerPosition;
            getMovementTargert();
        }

        if (attackCoolDown > 0)
        {
            attackCoolDown--;
        }
        if (playerCollider.IsTouching(HitBox))
        {
            death();
        }


    }
    protected virtual void  getMovementTargert()
    {

        
        Vector2 pos = GetComponent<Transform>().position;
        float xDistance = Mathf.Abs(Mathf.Abs(pos.x) - Mathf.Abs(target.x));
      
        if (notDead == true)
        {
            if (target.x < pos.x)
            {
                enemyAnimator.SetInteger("AnimState", 0);
                direction = 0;
            }
            else if (target.x > pos.x)
            {
                enemyAnimator.SetInteger("AnimState", 2);
                direction = 2;
            }
            moveEnemy(walkSpeed, direction);
        }


        
    }

    public abstract void moveEnemy(float speedX, int direction);

    protected virtual void attack()
    {
        playerController.damage();
        attackCoolDown = attackSpeed;
    }

    public virtual void death()
    {
        notDead = false;
        gameController.audioSources[(int)AudioClips.KILL].Play();
        if (direction == 0)
        {
            enemyAnimator.SetInteger("AnimState", 1);

        } else if (direction == 2)
        {
            enemyAnimator.SetInteger("AnimState", 3);
        }

        Destroy(this.gameObject, 1.0f);


    }


 


}

