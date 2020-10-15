using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
    [SerializeField] private float sprintingNoise;
    [SerializeField] private float walkingNoise;
    [SerializeField] private float crouchingNoise;
    [SerializeField] private string enemyTagName;

    public PlayerController playerController;
    public SphereCollider noiseCollider;
    public bool PlayerNoiseDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        noiseCollider.radius = walkingNoise;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isSprinting && !playerController.isStill)
        {
            noiseCollider.radius = sprintingNoise;
        } else if (playerController.isCrouching && !playerController.isStill)
        {
            noiseCollider.radius = crouchingNoise;
        } else if (playerController.isStill)
        {
            noiseCollider.radius = 0;
        } else
        {
            noiseCollider.radius = walkingNoise;
        }
        
        
    }
    void OnTriggerEnter(Collider noiseCollider)
    {
        if (noiseCollider.gameObject.tag.Equals("Enemy"))
        { 
            PlayerNoiseDetected = true;
        }
        
    }
    void OnTriggerExit(Collider collider)
    {
        
        if (collider.gameObject.tag.Equals("Enemy"))
        {
            PlayerNoiseDetected = false; 
        }
           
        
    }
}
