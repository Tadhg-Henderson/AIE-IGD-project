using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flashlight : MonoBehaviour 
{
    // Start is called before the first frame update
    [SerializeField] private float flashlightRange;
    [SerializeField] private KeyCode flashlightButton;

    public bool hittingEnemy;
    public Light flashlight;
    public Camera playerCamera;

    public bool flashLightIsEnabled = false;
    void Start()
    {
        flashlight.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(flashlightButton))
        {
            flashLightIsEnabled = !flashLightIsEnabled;
        }
        if (flashLightIsEnabled)
        {
            flashlight.gameObject.SetActive(true);
        } else if(!flashLightIsEnabled)
        {
            flashlight.gameObject.SetActive(false);
        }
        FlashlightShootRay();
    }

    private void FlashlightShootRay()
    {
        if (flashLightIsEnabled)
        {
            RaycastHit hit;
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, flashlightRange))
            {
                if(hit.collider.tag == "Enemy")
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
}
