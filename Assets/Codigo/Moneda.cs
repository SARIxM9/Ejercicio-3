using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int moneda;
    public AudioClip clip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Audio.Instance.ReproducirAudio(clip);
            GameManager.Instance.MonedaObtenida(moneda);
            Destroy(gameObject);
        }
    }
}
