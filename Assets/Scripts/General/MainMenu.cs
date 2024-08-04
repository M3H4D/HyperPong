using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool Player1 = true;
    public void PlayGame1_easy()
    {
        MainController.difficulty = 0;
    }
    
    public void PlayGame1_medium()
    {
        MainController.difficulty = 1;
    }

    public void PlayGame1_hard()
    {
        MainController.difficulty = 2;
    }

    public void load1Player()
    {
        Player1 = true;
    }

    public void load2Player()
    {
        Player1 = false;
    }

    public void loadGame()
    {
            if (Player1)
            {
                SceneManager.LoadScene("1 Player");
            }
            else
            {
                SceneManager.LoadScene("2 Player");
            } 
    }
}
