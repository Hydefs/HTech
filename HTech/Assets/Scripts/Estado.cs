using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Estado : MonoBehaviour
{
    public Player player;
    private TextMeshProUGUI textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        textMeshPro.text = "isDead: " + player.isDead;
    }
}
