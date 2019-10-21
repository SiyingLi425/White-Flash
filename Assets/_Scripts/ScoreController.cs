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

    // Update is called once per frame
    void Update()
    {
        
    }
}
