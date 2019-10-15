
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
    private Collider2D boundary;


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

    }

    // Update is called once per frame
    void Update()
    {
        if (boundary.IsTouching(playerCollider)) {
            Debug.Log("Respawn");
            player.transform.position = spawnPoint;
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

    /// <summary>
    /// restarts the game on click
    /// </summary>

   
}
