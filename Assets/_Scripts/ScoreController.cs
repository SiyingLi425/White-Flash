/*
 White Flash
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 21/10/2019
 Description: Deals with showing the score in win scence at start
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int score;
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreBoard").GetComponent<Score>().scoreValue;
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = score.ToString();
    }

}
