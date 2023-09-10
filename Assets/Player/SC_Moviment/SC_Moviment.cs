using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SC_Moviment : MonoBehaviour
{

private TrailRenderer TracoDaEsquiva;

    [Header("Movimentacao")]
    private new Rigidbody2D rigidbody2D;
    public float movimentoJogador = 4f;
    public float forcaPuloJogador = 500f;
    private bool taNoChao;

    [Header("Esquiva")]
    [SerializeField] private float velocidadeEsquiva = 14f;
    [SerializeField] private float tempoEsquiva = 0.5f;
    private Vector2 direcaoEsquiva;
    private bool esquivaAtiva;
    private bool podeEsquivar = true; 


    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>(); 
        TracoDaEsquiva = GetComponent<TrailRenderer>();
    }
    
    public void Update() {
        Esquivar();
    }

    public void FixedUpdate() 
    {
        Mover();
        Pular();
    }

    public void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Chao") 
        {
            taNoChao = true;
        }
    }

    public void Esquivar() {
       var botaoEsquiva = Input.GetButtonDown("Dash");

        if(podeEsquivar && botaoEsquiva)
        {
            esquivaAtiva = true;
            podeEsquivar = false;
            TracoDaEsquiva.emitting = true;
            direcaoEsquiva = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            if(direcaoEsquiva == Vector2.zero)
            {
                direcaoEsquiva = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine("PararEsquiva");
        }

        if (esquivaAtiva) {
            rigidbody2D.velocity = direcaoEsquiva.normalized * velocidadeEsquiva;
            return;
        }

        if (taNoChao) 
        {
            podeEsquivar = true;
        }
    }

    public IEnumerator PararEsquiva()
    {
        yield return new WaitForSeconds(tempoEsquiva);
        TracoDaEsquiva.emitting = false;
        esquivaAtiva = false;
    }

    public void Mover()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");

        if(!esquivaAtiva)
        rigidbody2D.velocity = new Vector2(inputHorizontal * movimentoJogador, rigidbody2D.velocity.y);
    }

    public void Pular() 
    {
        if (Input.GetKey("space") && taNoChao == true) 
        {
            rigidbody2D.AddForce(new Vector2(0f, forcaPuloJogador));
            taNoChao = false;
        }
    }
}

