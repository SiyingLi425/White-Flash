/*
 White Flash
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 19/10/2019
 Description: Deals with player movement, dying, animation, lives
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded;
    public RabbitAnimState rabbitAnimState;
    public Animator rabbitAnimator;
    public SpriteRenderer rabbitSpriteRenderer;
    public int speed;
    public int jumpForce;
    public Rigidbody2D rabbitRB;
    public Transform groundTarget;
    public int lives  = 5;
    public GameObject rabbitDeath;

    private Collider2D groundCollider;
    private Collider2D rabbitCollider;
    public int isJumping;
    public int jumpCountDown;
    public Text livesText;
    private bool canMove = true;
    private GameController gameController;
    public bool cheat = false;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        isJumping = 0;
        livesText.text = "Lives: " + lives;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();


    }

    // Update is called once per frame
    void Update()
    {
        if(jumpCountDown > 0)
        {
            jumpCountDown--;
        }

        //checks if is grounded
        isGrounded = Physics2D.BoxCast(transform.position, new Vector2(2f, 0.05f), 0.0f, Vector2.down, 0.6f, 1 << LayerMask.NameToLayer("Ground"));
        isJumping = isGrounded ? 0 : isJumping;
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                cheat = true;
            }

            //Idle State
            if (Input.GetAxis("Horizontal") == 0 && isGrounded)
            {
                rabbitAnimState = RabbitAnimState.IDLE;
                rabbitAnimator.SetInteger("AnimState", (int)RabbitAnimState.IDLE);
            }


            // Move Right
            if (Input.GetAxis("Horizontal") > 0)
            {
                rabbitSpriteRenderer.flipX = false;
                if (isGrounded || jumpCountDown > 10)
                {
                    rabbitAnimState = RabbitAnimState.RUN;
                    rabbitAnimator.SetInteger("AnimState", (int)RabbitAnimState.RUN);
                    rabbitRB.AddForce(Vector2.right * speed);
                }
            }

            // Move Left
            if (Input.GetAxis("Horizontal") < 0 )
            {
                rabbitSpriteRenderer.flipX = true;
                if (isGrounded || jumpCountDown > 10)
                {
                    rabbitAnimState = RabbitAnimState.RUN;
                    rabbitAnimator.SetInteger("AnimState", (int)RabbitAnimState.RUN);
                    rabbitRB.AddForce(Vector2.left * speed);
                }
            }

            // Jump
            if (((Input.GetAxis("Jump") > 0) && (isJumping < 2) && jumpCountDown == 0) || (cheat && (Input.GetAxis("Jump") > 0) && jumpCountDown == 0))
            {
                gameController.audioSources[(int)AudioClips.JUMP].Play();
                rabbitAnimState = RabbitAnimState.JUMP;
                rabbitAnimator.SetInteger("AnimState", (int)RabbitAnimState.JUMP);
                rabbitRB.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
                isJumping++;
                jumpCountDown = 20;



            }
        }
    }
    //gets hurt
    public void damage()
    {
        if (cheat == false)
        {
            if (lives != 0)
            {
                gameController.audioSources[(int)AudioClips.HURT].Play();
                lives--;
                livesText.text = "Lives: " + lives;

            }

            if (lives == 0)
            {
                death();
            }
        }
        
        
    }
    //dies and call gameover scene
    public void death()
    {
        gameController.audioSources[(int)AudioClips.DEATH].Play();
        canMove = false;   
        this.gameObject.SetActive(false);
        Instantiate(rabbitDeath, transform.position, transform.rotation);
        Destroy(rabbitDeath, 100.0f);
        Destroy(this.gameObject, 100.0f);
        gameController.lose();
    }

}
