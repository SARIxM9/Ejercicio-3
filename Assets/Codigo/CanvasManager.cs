using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI boton;

    public GameObject[] vida;

    public static CanvasManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Mas de un GameManager");
        }
    }

    public void Puntaje()
    {
        boton.text = GameManager.Instance.contador.ToString();
    }

    public void Activar(int vidas)
    {
        vida[vidas].SetActive(true);
    }

    public void Desactivar(int vidas)
    {
        vida[vidas].SetActive(false);
    }




}
