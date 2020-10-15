using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetection : MonoBehaviour
{

    public bool isHeard;
    public bool isSeen;

    private bool castRay;

    public PlayerNoise hearing;
    public Transform head;
    public Transform lastKnownPosition;
    public Transform player;


    private void Update()
    {
        HearingCheck();
        VisCheck();
    }
    private void HearingCheck()
    {
       if (hearing.PlayerNoiseDetected)
       {
            isHeard = true;
            castRay = true;
            if (isHeard)
            {
                head.LookAt(lastKnownPosition);
                lastKnownPosition.position = player.position;
            }
       } 
       if (hearing.PlayerNoiseDetected.Equals(false))
       {
            isHeard = false;
       }
    }
    private void VisCheck()
    {
        if(castRay)
        {
            RaycastHit hit;
            if(Physics.Raycast(head.position, head.forward, out hit , Mathf.Infinity))
            {
                if(hit.transform.tag == "Player")
                {
                    lastKnownPosition.position = player.position;
                    head.LookAt(lastKnownPosition);
                    castRay = true;
                    isSeen = true;
                    Debug.DrawRay(head.position, head.forward, Color.green);
                } else
                {
                    castRay = false;
                    isSeen = false;
                }
            }
        } 
    }
}

    
 

