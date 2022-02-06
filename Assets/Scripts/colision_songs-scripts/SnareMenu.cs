using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnareMenu : MonoBehaviour
{
    public GameObject sceneMana;

    private void OnTriggerEnter(Collider infoObjet)
    {

        if (infoObjet.gameObject.tag == "Drumsteaks" )
        {
            switch ((int)SceneManager.state)
            {
                case 0:
                    //appeler la fonction qui load tutoscene
                    sceneMana.GetComponent<SceneManager>().LoadTutoMenu();

                    break;
                case 1:
                    //appeler la fonction qui load TutoDemo
                    sceneMana.GetComponent<SceneManager>().LoadTutoDemo();

                    break;
                case 5:
                    //musique
                    sceneMana.GetComponent<SceneManager>().LoadTutoMenu();

                    break;
                default:
                    break;
            }
               
        }

    }
}
