using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    [Header("No Tocar >:(")]

    public int contador = 0;

    private int vidas = 2;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un GameManager");
        }
    }

    public void MonedaObtenida(int moneda)
    {
        contador += moneda;
        CanvasManager.Instance.Puntaje();
    }

    public bool SumarVida()
    {
        if (vidas == 2)
        {
            return true;
        }
        else
        {
            vidas++;
            CanvasManager.Instance.Activar(vidas);
            return false;
        }
    }

    public void RestarVida()
    {
        if (vidas == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            CanvasManager.Instance.Desactivar(vidas);
            vidas--;
        }


    }
}
