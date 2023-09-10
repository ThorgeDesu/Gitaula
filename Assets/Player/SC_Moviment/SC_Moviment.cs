using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Moviment : MonoBehaviour
{
[Header("Movimentacao do jogador")]
//TESTEEEEEEE
    private new Rigidbody2D rigidbody2D;
    public float movimentoJogador = 4f;
    public float forcaPuloJogador = 500f;
    private bool taNoChao;

[Header("Esquiva do jogador")]
    public float duracaoEsquiva = 0.5f;
    public float velocidadeEsquiva = 10f;
    private bool estaEsquiva = false;

public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); 

    }

public void FixedUpdate() 
{
    float inputHorizontal = Input.GetAxisRaw("Horizontal");
    {
        rigidbody2D.velocity = new Vector2(inputHorizontal * movimentoJogador, rigidbody2D.velocity.y);
    }        

    if (Input.GetKey("space") && taNoChao == true) 
    {
        rigidbody2D.AddForce(new Vector2(0f, forcaPuloJogador));
        taNoChao = false;
    }

    if (Input.GetKey("left shift") && !estaEsquiva)
    {
        StartCoroutine("ExecutarEsquiva");
    }

    }

public void OnCollisionEnter2D(Collision2D other) 
{
    if (other.gameObject.tag == "Chao") 
    {
        taNoChao = true;
    }
}

public IEnumerable ExecutarEsquiva()
{
    estaEsquiva = true;
    float tempoDecorrido = 0f;
    while (tempoDecorrido < duracaoEsquiva)
    {
        rigidbody2D.velocity = new Vector2(velocidadeEsquiva, rigidbody2D.velocity.y);
        tempoDecorrido += Time.deltaTime;
        yield return null;
    }
    estaEsquiva = false;
}

}

