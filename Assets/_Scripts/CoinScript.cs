/*
 Burn Em
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 29/09/2019
 Description: deals with animations, and sounds after the player collides with coin then self-destructs
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public GameController gameController;
    public int coinScoreValue;

    private AudioSource _coinSound;

    // Start is called before the first frame update
    void Start()
    {
        //finds gameController
        GameObject gameControllerObj = GameObject.FindWithTag("GameController");
        if (gameControllerObj != null)
        {
            gameController = gameControllerObj.GetComponent<GameController>();
        }

        if (gameController == null)
        {
            Debug.Log("Cannot find Game Controller script on Object");
        }

        _coinSound = gameController.audioSources[(int)AudioClips.COIN];
        
    }

    /// <summary>
    /// plays coin sounds and tell gameController to add score before self destruct
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            _coinSound.Play();
            gameController.AddScore(coinScoreValue);
            Destroy(this.gameObject);

        }
        
    }
}
