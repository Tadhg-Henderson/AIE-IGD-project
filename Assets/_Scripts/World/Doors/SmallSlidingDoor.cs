using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSlidingDoor : MonoBehaviour
{
    public Animator animator;
    public LeverTrigger lever;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isDoorOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lever.isTriggerd)
        {
            animator.SetBool("isDoorOpen", true);
        }
    }
}
