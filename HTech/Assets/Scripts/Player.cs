using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    Animator animator;

    public float velocidad = 10f;
    float movimientoHorizontal;
    public float fuerzaSalto = 300f;
    bool derecha = true;
    bool puedeSaltar = true;
    public bool powerUpSalto = false;
    public bool isDead = false;

    void Start()
    {
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
        if (collision.CompareTag("PowerupSalto") || collision.CompareTag("PowerupVelocidad"))
        {
            //Debug.Log("Test2");
            powerUpSalto = true;
            Destroy(collision.gameObject);
        }
    }


    private void Saltar()
    {
        puedeSaltar = false;
        animator.SetBool("Saltar", true);
        animator.SetBool("Suelo", false);

        rb.AddForce(new Vector2(0, fuerzaSalto));
    }

    private void Mover()
    {
        Vector2 movimiento = new Vector2(movimientoHorizontal * velocidad, rb.velocity.y);
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
