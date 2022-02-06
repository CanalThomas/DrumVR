using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/*using System.Enum;*/


public class ScoreManager : MonoBehaviour
{
    enum Etat
    {
        MAIN,
        TUTO_MENU,
        TUTO_FOUR_FIRST,
        TUTO_PLAY,
        TUTO_DEMO,
        FREE_MENU,
        FREE_PLAY,
        TUTO_FOUR_FIRST_DEMO
    }

    private Image[] notes;
    public double bpm = 60;
    private double spb;
    private double nextTime;
    private double midNextTime;

    private int compteur;
    public GameObject sceneMana;
    //public Etat SceneManager.

    public GameObject Snare;
    public GameObject Kick;
    public GameObject HitHat;

    public AudioSource SnareClip;
    public AudioSource KickClip;
    public AudioSource HitaHatClip;

    public Material SnareMaterial;
    public Material KickMaterial;
    public Material HitaHatMaterial;

    public Material SnareMaterialInit;
    public Material KickMaterialInit;
    public Material HitaHatMaterialInit;

    private bool demo = true; // a changer selon si on choisit demo ou play
    public AudioSource metronome;  

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(SceneManager.state);
        metronome.GetComponent<AudioSource>();
        notes = new Image[24];
        Image[] score = GetComponentsInChildren<Image>();
        for (int i = 1; i < score.Length; i++)
        {
            notes[i-1] = score[i];
        }

        //bpm = 60;
        spb = 60 / bpm;
        midNextTime = Time.realtimeSinceStartup + spb / 2;
        nextTime = Time.realtimeSinceStartup + spb;//AudioSettings.dspTime + spb;
        
        Invoke("StartMetronome", 1.0f);




    }

    // Update is called once per frame
    void Update()
    {
        if (midNextTime < Time.realtimeSinceStartup && midNextTime > 0 && demo) TurnOffHighlight();

        if (((Etat)SceneManager.state == Etat.TUTO_PLAY || (Etat)SceneManager.state == Etat.TUTO_DEMO || (Etat)SceneManager.state == Etat.TUTO_FOUR_FIRST || (Etat)SceneManager.state == Etat.TUTO_FOUR_FIRST_DEMO) && Time.realtimeSinceStartup >= nextTime)
        {
            

            Debug.Log(SceneManager.state);

            if ((Etat)SceneManager.state == Etat.TUTO_FOUR_FIRST)
            {
                compteur++;
                if (compteur == 5)
                {
                    compteur = 0;
                    SceneManager.state = ((Etat)SceneManager.state == Etat.TUTO_FOUR_FIRST)?(SceneManager.Etat)SceneManager.Etat.TUTO_PLAY: (SceneManager.Etat)SceneManager.Etat.TUTO_DEMO;
                }
            }

            if (compteur == 24) MetronomeReset();

            //Jouer un son
            nextTime = Time.realtimeSinceStartup + spb;
            midNextTime = Time.realtimeSinceStartup + spb / 2;
            metronome.Play();
            if((Etat)SceneManager.state != Etat.TUTO_FOUR_FIRST) DisplayScore();

            
        }
    }

    void StartMetronome()
    {
        compteur = 0;
        SceneManager.state = (SceneManager.Etat)Etat.TUTO_FOUR_FIRST;
    }

    void DisplayScore()
    {
        
            if(compteur%6 == 0)
            {
                notes[compteur].sprite = Resources.Load<Sprite>("HitHatBlue");
                compteur++;
                notes[compteur].sprite = Resources.Load<Sprite>("KickRed");
                compteur++;
                if (demo)
                {
                ///TODO///
                //On colorie et active les partie adequat : kick et hithat
                    KickClip.GetComponent<AudioSource>().Play();
                    HitaHatClip.GetComponent<AudioSource>().Play();

                    Kick.GetComponent<Renderer>().material = KickMaterial;
                    HitHat.GetComponent<Renderer>().material = HitaHatMaterial;
                }                
            }
            else if (compteur % 6 == 3)
            {
                notes[compteur].sprite = Resources.Load<Sprite>("HitHatBlue");
                compteur++;
                notes[compteur].sprite = Resources.Load<Sprite>("SnareGreen");
                compteur++;
                if (demo)
                {
                    ///TODO///
                    //On colorie et active les partie adequat : snare et hithat
                    SnareClip.GetComponent<AudioSource>().Play();
                    HitaHatClip.GetComponent<AudioSource>().Play();

                    Snare.GetComponent<Renderer>().material = SnareMaterial;
                    HitHat.GetComponent<Renderer>().material = HitaHatMaterial;

                }
            }
            else if (compteur % 6 == 2 || compteur % 6 == 5)
            {
                notes[compteur].sprite = Resources.Load<Sprite>("HitHatBlue");
                compteur++;
                if (demo)
                {
                ///TODO///
                //On colorie et active la partie adequat : hithat
                HitaHatClip.GetComponent<AudioSource>().Play();

                HitHat.GetComponent<Renderer>().material = HitaHatMaterial;

            }
        }
        
    }

    void TurnOffHighlight()
    {
        if (compteur % 6 == 2)
        {
            Kick.GetComponent<Renderer>().material = KickMaterialInit;
            HitHat.GetComponent<Renderer>().material = HitaHatMaterialInit;
        }
        else if (compteur % 6 == 5)
        {
            Snare.GetComponent<Renderer>().material = SnareMaterialInit;
            HitHat.GetComponent<Renderer>().material = HitaHatMaterialInit;
        }
        else if (compteur % 6 == 3 || compteur % 6 == 0)
        {
            HitHat.GetComponent<Renderer>().material = HitaHatMaterialInit;
        }
        
        midNextTime = 0;
    }

    void MetronomeReset()
    {
        ///TODO///
        ///Carrement appeler la fonction loadtutoscene qui mettra le state a la bonne valeur
        sceneMana.GetComponent<SceneManager>().LoadTutoMenu();
        //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

}

