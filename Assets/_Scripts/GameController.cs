/*
 White Flash
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 19/10/2019
 Description: Deals with audios, player respawn after falling, score keeping, win 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    

    [Header("Sound Settings")]
    public AudioClips activeAudio;
    public AudioSource[] audioSources;


    [Header("UI Options")]
    public Text scoreText;

    [Header("ReSpawn Settings")]
    private Vector2 spawnPoint;
    private Collider2D respawnMushroom;
    private Collider2D boundary;
    private int respawnPointTimer;

    [Header("Boss Settings")]
    private GameObject boss;
    private Collider2D bossCollider;
    public GameObject goal;
    private Collider2D goalCollider;

    //Scores Settings
    private GameObject scoreBoard;


    // Private variables
    private int score = 0;
    private GameObject player;
    private PlayerController playerController;
    private Collider2D playerCollider;
    private GameObject gameover;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerCollider = player.GetComponent<PolygonCollider2D>();
        scoreBoard = GameObject.FindGameObjectWithTag("ScoreBoard");
        UpdateScore();
        boundary = GameObject.FindGameObjectWithTag("Boundary").GetComponent<BoxCollider2D>();
        spawnPoint = player.transform.position;
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossCollider = boss.GetComponent<BoxCollider2D>();
        goal = GameObject.FindGameObjectWithTag("Goal");
        goalCollider = goal.GetComponent<BoxCollider2D>();
        goal.SetActive(false);
        respawnMushroom = GameObject.FindGameObjectWithTag("RespawnPoint").GetComponent<UnityEngine.Tilemaps.TilemapCollider2D>();
        gameover = GameObject.FindGameObjectWithTag("GameOver");
        gameover.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(respawnPointTimer > 0)
        {
            respawnPointTimer--;
        }
        //set new respawn point
        if (respawnMushroom.IsTouching(playerCollider) && respawnPointTimer == 0){
            audioSources[(int)AudioClips.MUSHROOM].Play();
            spawnPoint = new Vector2(player.transform.position.x, player.transform.position.y + 2.0f);
            respawnPointTimer = 200;
        }

        //respawn player 
        if (boundary.IsTouching(playerCollider)) {
            Debug.Log("Respawn");
            player.transform.position = spawnPoint;
        }
        

        //When player goes towards goal, calls win
        if (goalCollider.IsTouching(playerCollider))
        {
            DontDestroyOnLoad(scoreBoard);
            win();
        }
        
    }



    /// <summary>
    /// updates score and lives
    /// </summary>
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
        scoreBoard.GetComponent<Score>().scoreValue = score;

    }

    // adds score and calls the updateScore method.
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    /// <summary>
    /// loads in the win scene
    /// </summary>
    public void win()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
        
    }

    public void lose()
    {
        gameover.SetActive(true);
    }
    public void bossDefeat()
    {
        goal.SetActive(true);
    }


   
}
