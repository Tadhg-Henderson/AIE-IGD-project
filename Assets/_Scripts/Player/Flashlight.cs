using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Flashlight : MonoBehaviour 
{
    // Start is called before the first frame update
    [SerializeField] private float flashlightRange;
    [SerializeField] private KeyCode flashlightButton;
    [SerializeField] private float regen;
    [SerializeField] private float drain;

    public Slider slider;
    public bool hittingEnemy;
    public Light flashlight;
    public Camera playerCamera;

    public bool canUseFlashlight;
    private float currentCharge;
    private float maxCharge = 100;

    public bool flashLightIsEnabled = false;
    void Start()
    {
        currentCharge = maxCharge;
        flashlight.gameObject.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        canUseFlashlightCheck();
        flashlightOverchargeCheck();
        slider.value = currentCharge;
        if (!canUseFlashlight)
        {
            flashLightIsEnabled = false;
        }
        if (Input.GetKeyDown(flashlightButton))
        {
            flashLightIsEnabled = !flashLightIsEnabled;
        }
    if (flashLightIsEnabled)
       {
                flashlight.gameObject.SetActive(true);
       }
    else if (!flashLightIsEnabled)
            {
                flashlight.gameObject.SetActive(false);
            }
            FlashlightShootRay();
        
    }
    private void FixedUpdate()
    {
        if (flashLightIsEnabled && currentCharge > 0)
        {
            currentCharge -= drain;
        } else if (currentCharge < maxCharge)
        {
            currentCharge += regen;
        }
    }

    private void FlashlightShootRay()
    {
        if (flashLightIsEnabled)
        {
            RaycastHit hit;
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, flashlightRange))
            {
                if(hit.transform.tag == "Enemy")
                {
                    hittingEnemy = true;
                } else
                {
                    hittingEnemy = false;
                }

                
            }
        } else
        {
            hittingEnemy = false;
        }
    }
    private void flashlightOverchargeCheck()
    {
        if (currentCharge > maxCharge)
        {
            currentCharge = maxCharge;
        }
        if (currentCharge < 0)
        {
            currentCharge = 0;
        }
    }
    private void canUseFlashlightCheck()
    {
        if (currentCharge > 0)
        {
            canUseFlashlight = true;
        } else if (currentCharge == 0)
        {
            canUseFlashlight = false;
        }
    }
}
