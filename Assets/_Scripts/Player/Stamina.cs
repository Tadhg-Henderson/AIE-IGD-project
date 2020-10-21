using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    [SerializeField] private float drain;
    [SerializeField] private float regen;

    public bool canSprint;
    public bool fullDrain;
    public Slider staminaBar;


    PlayerController controller;
    public float currentStamina;
    private float maxStamina = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        controller = gameObject.GetComponent<PlayerController>();
    }
    private void Update()
    {
        CanSprintCheck();
        FullDrainCheck();
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
        if (currentStamina < 0)
        {
            currentStamina = 0;
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        
        staminaBar.value = currentStamina;
        if (controller.isSprinting && !fullDrain)
        {
            currentStamina -= drain;
        } else if (currentStamina < maxStamina && fullDrain)
        {
            currentStamina += drain;
        } else if (currentStamina < maxStamina)
        {
            currentStamina += regen;
        }
        
    }
    private void FullDrainCheck() {
        {
            if (currentStamina <= 0)
            {
                fullDrain = true;
            }
            if (currentStamina.Equals(100))
            {
                fullDrain = false;
            }
        }
    }
    private void CanSprintCheck()
    {
        if (currentStamina > 0 && !fullDrain)
        {
            canSprint = true;
        } else
        {
            canSprint = false;
        }
       
    }
    
}
