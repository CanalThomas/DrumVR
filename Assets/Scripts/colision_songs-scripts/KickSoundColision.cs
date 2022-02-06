using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class KickSoundColision : MonoBehaviour
{
    private GameObject go;
    private Queue<GameObject> goQueue;
    public AudioClip Audio;
    private void Start()
    {
        goQueue = new Queue<GameObject>(50);
        for (int i = 0; i < goQueue.Count; i++)
        {
            go = new GameObject();
            go.transform.parent = transform;
            go.transform.position = transform.position;
            go.AddComponent<AudioSource>().clip = Audio;
            goQueue.Enqueue(go);
        }
    }

    private void Update()
    {
        int taille = goQueue.Count;
        for (int i = 0; i < 50 - taille; i++)
        {
            go = new GameObject();
            go.transform.parent = transform;
            go.transform.position = transform.position;
            go.AddComponent<AudioSource>().clip = Audio;
            goQueue.Enqueue(go);
        }

        if (Input.GetKeyDown("space"))
        {
            goQueue.Dequeue().GetComponent<AudioSource>().Play();
        }

    }



}
