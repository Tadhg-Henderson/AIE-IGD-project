using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverTurnLightOff : MonoBehaviour
{
    public LeverTrigger lever;

    void Update()
    {
        if (lever.isTriggerd)
        {
            gameObject.SetActive(false);
        }
    }
}
