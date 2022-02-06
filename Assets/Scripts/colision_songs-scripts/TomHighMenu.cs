using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomHighMenu : MonoBehaviour
{
    public GameObject sceneMana;

    private void OnTriggerEnter(Collider infoObjet)
    {

        if (infoObjet.gameObject.tag == "Drumsteaks")
        {
            switch ((int)SceneManager.state)
            {
                case 0:
                    //appeler la fonction qui load freeScene
                    sceneMana.GetComponent<SceneManager>().LoadFreeMenu();
                    break;
                case 1:
                    //appeler la fonction qui load playmode
                    sceneMana.GetComponent<SceneManager>().LoadTutoPlay();
                    break;
                case 5:
                    //appeler Start
                    sceneMana.GetComponent<SceneManager>().LoadFreePlay();
                    break;
                default:
                    break;
            }

        }

    }
}
