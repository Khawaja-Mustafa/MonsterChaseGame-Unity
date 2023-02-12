using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void HomeScreen()
    {
        ////Both functions can be used
        SceneManager.LoadScene("MainMenue");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RetryGame()
    {
        SceneManager.LoadScene("Gameplay");
    }
}//Class
