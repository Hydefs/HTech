using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Efecto : MonoBehaviour
{
    public abstract void AplicarEfecto(GameObject player);

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }*/
}
