using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockDoor : MonoBehaviour
{
    public bool isOpen = false;
    Animator animator;
    public LeverTrigger leverTrigger1;
    public LeverTrigger leverTrigger2;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        animator.SetBool("IsOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (leverTrigger1.isTriggerd && leverTrigger2.isTriggerd)
        {
            animator.SetBool("IsOpen", true);
        }

    }
}
