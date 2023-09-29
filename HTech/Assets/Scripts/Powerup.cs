using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Efecto efecto;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Test");
        Destroy(gameObject);
        efecto.AplicarEfecto(collision.gameObject);

    }
}
