using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caracteristica : MonoBehaviour
{
    public float valor;
    public bool powerup = false;
    public void AplicarEfecto(float multiplicador, int duracion)
    {
        valor *= multiplicador;
        powerup = true;
        StartCoroutine(TemporizadorPowerup(multiplicador, duracion));
    }

    public void QuitarPowerup(float multiplicador)
    {
        valor /= multiplicador;
        powerup = false;
    }

    private IEnumerator TemporizadorPowerup(float multiplicador, int duracion)
    {
        yield return new WaitForSeconds(duracion);
        QuitarPowerup(multiplicador);
    }
}
