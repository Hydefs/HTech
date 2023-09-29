using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidad : Efecto
{
    [Range(1,2)] public float multiplicador = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AplicarEfecto(collision.gameObject);
    }

    public override void AplicarEfecto(GameObject player)
    {
        player.GetComponent<Player>().velocidad *= multiplicador;
    }
}
