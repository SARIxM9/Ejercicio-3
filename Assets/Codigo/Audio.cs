using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de una instancia");
        }
    }


    public AudioSource source;
    public void ReproducirAudio(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
