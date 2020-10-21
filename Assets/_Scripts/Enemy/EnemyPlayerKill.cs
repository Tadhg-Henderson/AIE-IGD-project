using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPlayerKill : MonoBehaviour
{
    public GameObject Player;
    public bool playerIsdead;
    void Awake()
    {
         playerIsdead = false;
}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBody")
        {
            Player.SetActive(false);
            playerIsdead = true;
        }
    }
}
