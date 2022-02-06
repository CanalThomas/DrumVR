using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.DefaultControls;


public class SceneManager : MonoBehaviour
{
    static public Etat state = Etat.MAIN;
    public GameObject snare;
    public GameObject highTom;
    public GameObject mediumTom;
    public enum Etat
    {
        MAIN,
        TUTO_MENU,
        TUTO_FOUR_FIRST,
        TUTO_PLAY,
        TUTO_DEMO,
        FREE_MENU,
        FREE_PLAY
    }

    void Start()
    {
        //Debug.Log("rrrr");
       // UnityEngine.SceneManagement.SceneManager.LoadScene("TutoScene");
    }
    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");

        snare.SetActive(true);
        highTom.SetActive(true);
        mediumTom.SetActive(true);

        //TODO : Mettre les bon sprite aux materials




        state = Etat.MAIN;
    }

    public void LoadTutoMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TutoScene");

        snare.SetActive(true);
        highTom.SetActive(true);
        mediumTom.SetActive(true);

        //TODO : Mettre les bon sprite aux materials
        state = Etat.TUTO_MENU;
    }

    public void LoadTutoPlay()
    {
        snare.SetActive(false);
        highTom.SetActive(false);
        mediumTom.SetActive(false);

        state = Etat.TUTO_FOUR_FIRST;
    }


    public void LoadTutoDemo()
    {
        //enelever le menu
        snare.SetActive(false);
        highTom.SetActive(false);
        mediumTom.SetActive(false);

        state = Etat.TUTO_FOUR_FIRST;
    }



    //  FREE        //
    public void LoadFreeMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FreeScene");

        snare.SetActive(true);
        highTom.SetActive(true);
        mediumTom.SetActive(true);


        //TODO : Mettre les bon sprite aux materials
        state = Etat.FREE_MENU;
    }

    public void LoadFreePlay()
    {
        snare.SetActive(false);
        highTom.SetActive(false);
        mediumTom.SetActive(false);

        state = Etat.FREE_PLAY;
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }

    // Cette fonction est appelée lors de l'appui sur le bouton menu de la manette si on est dans la scene de tuto ou la scene libre
    /*public void ChangeIsPaused()        
    {
        //if (isPaused == true) return;

        if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "FreeScene")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        else if(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "TutoScene")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); 
        }


        //isPaused = !isPaused;
    }*/
}