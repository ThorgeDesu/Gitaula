using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SC_Portal : MonoBehaviour
{
[Header("Jogador interagir com o teleporte")]
public int portalID;
public GameObject jogador;
private bool podeTeleporta = true;
void Start()
    {

    }
void Update()
    {
        
    }
void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e"))
        {
            TeleportPlayer(other.gameObject);
        }    
    }    

void TeleportPlayer(GameObject player)
    {
        int targetportalID = (portalID == 1) ? 2 : 1;
        GameObject[] portals = GameObject.FindGameObjectsWithTag("Portal");

        foreach (GameObject portal in portals)
        {
            SC_Portal portalScript = portal.GetComponent<SC_Portal>();
            if (portalScript.portalID == targetportalID)
            {
                player.transform.position = portal.transform.position;
                break;
            }
        }
    }

}

