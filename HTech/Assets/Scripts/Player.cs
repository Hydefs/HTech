using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator;

    Salto salto;
    Velocidad velocidad;
    float movimientoHorizontal;
    bool derecha = true;
    bool puedeSaltar = true;
    public bool isDead = false;

    void Start()
    {
        salto = GetComponent<Salto>();
        velocidad = GetComponent<Velocidad>();
        rb = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movimientoHorizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Altura", rb.velocity.y);
        Mover();
        if (Input.GetButtonDown("Jump") && puedeSaltar)
        {
            Saltar();
        }
        if( movimientoHorizontal < 0 && derecha) 
        {
            VerificarGiro();
        }
        else if( movimientoHorizontal > 0 && !derecha)
        {
            VerificarGiro();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Piso")
        {
            puedeSaltar = true;
            animator.SetBool("Saltar", false);
            animator.SetBool("Suelo", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!salto.powerup && collision.CompareTag("PowerupSalto"))
        {
            Powerup powerup = collision.GetComponent<Powerup>();
            salto.AplicarEfecto(powerup.multiplicador, powerup.duracion);
            Destroy(collision.gameObject);

        }
        if (!velocidad.powerup && collision.CompareTag("PowerupVelocidad"))
        {
            Powerup powerup = collision.GetComponent<Powerup>();
            velocidad.AplicarEfecto(powerup.multiplicador, powerup.duracion);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Enemigo"))
        {
            isDead = true;
            Destroy(collision.gameObject);
        }
    }  

    private void Saltar()
    {
        puedeSaltar = false;
        animator.SetBool("Saltar", true);
        animator.SetBool("Suelo", false);

        rb.AddForce(new Vector2(0, salto.valor));
    }

    private void Mover()
    {
        Vector2 movimiento = new Vector2(movimientoHorizontal * velocidad.valor, rb.velocity.y);
        rb.velocity = movimiento;

        if(Mathf.Abs(movimientoHorizontal) > 0 && puedeSaltar)
        {
            animator.SetBool("Correr", true);
        }
        else
        {
            animator.SetBool("Correr", false);
        }
    }

    private void VerificarGiro()
    {
        derecha = !derecha;
        Vector2 vectorGiro = transform.localScale;
        vectorGiro.x *= -1;
        transform.localScale = vectorGiro;  
    }

}
