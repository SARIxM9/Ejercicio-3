using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public GameObject jugador;
    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Audio.Instance.ReproducirAudio(clip);           
            jugador.gameObject.GetComponent<Jugador>().Empujar();
            GameManager.Instance.RestarVida();
            Destroy(gameObject);
        }
    }
}
