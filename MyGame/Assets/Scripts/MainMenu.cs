using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    public Transform mainMenu, HighScore;
    
    // calls the sceen to be loaded
    public void LoadScene(string name)
    {
        Application.LoadLevel(name);
    }
    public void quit()
    {
        Application.Quit();
    }

    /*
    public void HScore(bool click)
    {
        if (click == true)
        {
            HighScore.gameObject.SetActive(click);
            mainMenu.gameObject.SetActive(false);
        }
        else
        {
            HighScore.gameObject.SetActive(click);
            mainMenu.gameObject.SetActive(true);
        }
    }*/
    
}
