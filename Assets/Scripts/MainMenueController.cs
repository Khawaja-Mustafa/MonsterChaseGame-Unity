using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenueController : MonoBehaviour
{
    public void PlayGame()
    {
        //Debug.Log("button is pressed");
        SceneManager.LoadScene("Gameplay");
    }
}
