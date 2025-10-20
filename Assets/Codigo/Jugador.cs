using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Atributos")]

    public Rigidbody2D rb;
    public SpriteRenderer Sprite;
    public Animator animator;

    [Header("Fuerzas")]

    public float velocidad;
    public float salto;
    public float impulso;

    [Header("Audio")]

    public AudioClip clip;

    [Header("Otros")]

    public int SaltoDoble;
    private int permitir;
    public bool Stun = true;


    private void Update()
    {
        Caminar();
        Saltar();
    }

    private void Caminar()
    {
        if(!Stun)
        {
            animator.SetBool("Kill", true);
            return;
        }
        else
        {
            animator.SetBool("Kill", false);
        }

        float horizontal = Input.GetAxis("Horizontal");
        
        rb.velocity = new Vector2(horizontal * velocidad,rb.velocity.y);

        if (rb.velocity.x < 0)
        {
            Sprite.flipX = true;
        }
        if (rb.velocity.x > 0)
        {
            Sprite.flipX = false;
        }

        if(rb.velocity.x != 0)
        {
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }
    }


    private void Saltar()
    {
        if (Piso.Tocapiso)
        {
            animator.SetBool("Jump", false);
            permitir = SaltoDoble;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Audio.Instance.ReproducirAudio(clip);
                permitir -= 1;
                rb.AddForce(new Vector2(rb.velocity.x, salto), ForceMode2D.Impulse);
            }
        }
        else
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            if (permitir > 0)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Audio.Instance.ReproducirAudio(clip);
                    permitir -= 1;
                    rb.velocity= new Vector2(rb.velocity.x,1);
                    rb.AddForce(new Vector2(rb.velocity.x, salto), ForceMode2D.Impulse);
                }
            }
        }

    }

    public void Empujar()
    {
        Stun = false;
        if(rb.velocity.x > 0)
        {
            rb.AddForce(new Vector2(-impulso, impulso));
        }
        else if (rb.velocity.x < 0)
        {
            rb.AddForce(new Vector2(impulso, impulso));
        }
        else
        {
            rb.AddForce(new Vector2(rb.velocity.x, 1000));
        }

        StartCoroutine(Tiempo());
    }
    IEnumerator Tiempo()
    {
        yield return new WaitForSeconds(0.1f);

        while (!Piso.Tocapiso)
        {
            yield return null;
        }
        Stun = true;

    }

}
