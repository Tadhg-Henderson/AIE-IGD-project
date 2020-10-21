using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLock : MonoBehaviour
{
    public bool airlockToggle;
    public Animator door1;
    public Animator door2;
    public GameObject Enemy;
    
    // Start is called before the first frame update
    
    void Start()
    {
        airlockToggle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (airlockToggle)
        {
            door1.SetBool("isDoorOpen", true);
            door2.SetBool("isDoorOpen", false);
        } else if (!airlockToggle)
        {
            
            Enemy.SetActive(true);
            door1.SetBool("isDoorOpen", false);
            door2.SetBool("isDoorOpen", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBody")
        {
            airlockToggle = !airlockToggle;
        }
    }
}
