using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EscapeManger : MonoBehaviour
{
    public bool playerHasEscaped = false;
    public GameObject player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBody")
        {
            playerHasEscaped = true;
            player.SetActive(false);
        }
    } 
}
