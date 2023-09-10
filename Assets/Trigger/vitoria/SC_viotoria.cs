using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
[Header("Sistema de vitoria")]
public Transform posicaoInicial;
public GameObject victoryMessage;
public Transform destination;
private bool jaGanhou = false;

void OnTriggerEnter2D(Collider2D jogador) {
    if (jogador.CompareTag("triggerVitoria") && !jaGanhou == true)
    {
        transform.position = posicaoInicial.transform.position;

        jaGanhou = false;
    }

    if (jogador.CompareTag("Player"))
    {
        jogador.transform.position = destination.position;

        jaGanhou = true;
    }

}
}
