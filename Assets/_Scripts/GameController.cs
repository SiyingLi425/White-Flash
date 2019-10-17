
/*
 Burn Em
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 29/09/2019
 Description: spawn ghosts, calculates and records player lives, deals with player death animations,
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

    [Header("Boss Settings")]
    private GameObject boss;
    private Collider2D bossCollider;
    public GameObject goal;
    private Collider2D goalCollider;

    // Private variables
    private int score = 0;
    private GameObject player;
    private PlayerController playerController;
    private Collider2D playerCollider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerCollider = player.GetComponent<PolygonCollider2D>();
        UpdateScore();
        boundary = GameObject.FindGameObjectWithTag("Boundary").GetComponent<BoxCollider2D>();
        spawnPoint = player.transform.position;
        boss = GameObject.FindGameObjectWithTag("Boss");
        bossCollider = boss.GetComponent<BoxCollider2D>();
        goal = GameObject.FindGameObjectWithTag("Goal");
        goalCollider = goal.GetComponent<BoxCollider2D>();
        goal.SetActive(false);
        respawnMushroom = GameObject.FindGameObjectWithTag("RespawnPoint").GetComponent<UnityEngine.Tilemaps.TilemapCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (respawnMushroom.IsTouching(playerCollider)){
            Debug.Log("Mushroom");
            spawnPoint = player.transform.position;
        }

        if (boundary.IsTouching(playerCollider)) {
            Debug.Log("Respawn");
            player.transform.position = spawnPoint;
        }
        //if (bossCollider.IsTouching(playerCollider))
        //{
        //    goal.SetActive(true);
        //}
        if (goalCollider.IsTouching(playerCollider))
        {
            win();
        }
        
    }



    /// <summary>
    /// updates score and lives
    /// </summary>
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;

    }

    // adds score and calls the updateScore method.
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void win()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
        
    }

    /// <summary>
    /// restarts the game on click
    /// </summary>

   
}
