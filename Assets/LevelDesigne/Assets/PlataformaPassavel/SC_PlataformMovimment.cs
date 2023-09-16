using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlataformMovimment : MonoBehaviour
{
[Header("Sistema para o jogador subir e descer da plataforma")]
public Transform player;
private BoxCollider2D boxCollider2D;
public bool podeDescer;
public bool colldownDescida;
public float tempoCD;
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }


    void Update() 
    {
        if(player.transform.localPosition.y < gameObject.transform.localPosition.y) 
        {
            boxCollider2D.enabled = false;
        } else if (podeDescer) 
            {
                boxCollider2D.enabled = false;
            } else 
                {
                    boxCollider2D.enabled = true;
                }
        
    }

    public void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.S))
        {
            podeDescer = true;
            colldownDescida = true;
            StartCoroutine("CDPlataform");
        }    
    }

    public IEnumerator CDPlataform()
    {
        yield return new WaitForSeconds(tempoCD);
        colldownDescida = false;
        podeDescer = false;
    }
}
