using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : Efecto
{
    [Range(1,3)] public int multiplicador = 1;
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
        player.GetComponent<Player>().fuerzaSalto *= multiplicador;
    }
}
