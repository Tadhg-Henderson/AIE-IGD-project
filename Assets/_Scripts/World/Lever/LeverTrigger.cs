using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTrigger : MonoBehaviour
{
    public bool isTriggerd;
    public bool playerInBounds;
    Animator animator;
    SphereCollider triggerRange;
    // Start is called before the first frame update
    void Start()
    {
        isTriggerd = false;
        animator = gameObject.GetComponent<Animator>();
        triggerRange = gameObject.GetComponent<SphereCollider>();
        animator.SetBool("isTriggered", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInBounds && Input.GetKeyDown(KeyCode.E))
        {
            isTriggerd = true;
            animator.SetBool("isTriggered", true);
        }

    }
    void OnTriggerStay(Collider Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            playerInBounds = true;
        }
    }
    void OnTriggerExit(Collider Other)
    {
        if (Other.gameObject.name == "Player")
        {
            playerInBounds = false;
        }
    }
}
