/*
 White Flash
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 21/10/2019
 Description: simply loads main scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    //Just loads main scene 
   public void onClickStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
