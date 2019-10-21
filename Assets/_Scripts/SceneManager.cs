/*
 White Flash
 Auther: Siying Li
 Last Modified By Siying Li
 Date last modified: 19/10/2019
 Description: simply loads main scene
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
   public void onClickStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
}
