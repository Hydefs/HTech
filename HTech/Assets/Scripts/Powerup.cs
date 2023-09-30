using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float multiplicador;
    [Range(3,5)] public int duracion;
    public void AplicarEfecto(float powerupValor, bool powerupBoolean)
    {

    }
    public void QuitarEfecto(float powerupValor, bool powerupBoolean)
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
