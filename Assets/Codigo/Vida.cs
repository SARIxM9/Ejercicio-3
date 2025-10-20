using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    private bool permitir;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            permitir = GameManager.Instance.SumarVida();
            if (!permitir)
            {
                Destroy(gameObject);
            }
        }
    }
}
