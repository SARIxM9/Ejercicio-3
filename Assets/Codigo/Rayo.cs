using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Rayo : MonoBehaviour
{
    public float distancia;
    public bool piso;
    public LayerMask mask;

    private void Update()
    {
        PisoRay();
    }


    private void PisoRay()
    {
        RaycastHit2D rayo = Physics2D.Raycast(transform.position, Vector2.down, distancia,mask);
        Debug.DrawRay(transform.position, Vector2.down * distancia, Color.green);
        if (rayo)
        {
            piso = true;
        }
        else
        {
            piso = false;
        }
    }
}
