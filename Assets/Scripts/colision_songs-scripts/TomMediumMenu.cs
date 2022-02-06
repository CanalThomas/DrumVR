using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TomMediumMenu : MonoBehaviour
{
    public GameObject sceneMana;

    private void OnTriggerEnter(Collider infoObjet)
    {

        if (infoObjet.gameObject.tag == "Drumsteaks")
        {
            
            switch ((int)SceneManager.state)
            {
                case 0:
                    Debug.Log(" YOYYOYOYOYOYOYOYOYOOYOYYOYOYOYOYO");
                    Application.Quit();
                    break;
                case 1:
                    Debug.Log(" YOYYOYOYOYOYOYOYOYOOYOYYOYOYOYOYO");
                    Debug.Log((int)SceneManager.state);
                    sceneMana.GetComponent<SceneManager>().LoadMainMenu();
                    break;
                case 5:
                    //appeler la fonction qui load MainScene
                    Debug.Log(" YOYYOYOYOYOYOYOYOYOOYOYYOYOYOYOYO");
                    sceneMana.GetComponent<SceneManager>().LoadMainMenu();
                    break;
                default:
                    break;
            }

        }

    }
}
