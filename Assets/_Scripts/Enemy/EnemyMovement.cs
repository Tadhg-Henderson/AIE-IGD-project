using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float defaultMovementSpeed = 5;
    [SerializeField] private float angeredMovementSpeed = 7;
    [SerializeField] private float slowedMovementSpeed = 3;
    
    
    public bool playerFound;
    
    public Transform lastKnownLocation;
    public Transform player;
    public EnemyPlayerDetection detection;
    public Transform[] waypoints;
    public Flashlight lighthit;
    public Animator animator;
    private NavMeshAgent agent;
    private int destPoint = 0;
    private SphereCollider killSphere;

    // Start is called before the first frame update
    void Start()
    {
        
        agent = gameObject.GetComponent<NavMeshAgent>();
        killSphere = gameObject.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (detection.isHeard || detection.isSeen)
        {
            playerFound = true;
        } else
        {

            playerFound = false;
        }
        if (!lighthit.hittingEnemy)
        {
            
            if (playerFound)
            {
                PlayerFoundMovement();
                
            }
            if (playerFound.Equals(false))
            {
                NormalMovement();
            }
            
        } else
        {
            StunnedMovement();
        }
    }
    private void PlayerFoundMovement()
    {
        
        agent.speed = angeredMovementSpeed;
        animator.SetBool("IsWalking", false);
        animator.SetBool("isStunned", false);
        agent.SetDestination(lastKnownLocation.position);
        killSphere.radius = 1.0f;
    }
    private void NormalMovement()
    {
        
        agent.speed = defaultMovementSpeed;
        agent.autoBraking = false;
        animator.SetBool("IsWalking", true);
        animator.SetBool("isStunned", false);
        killSphere.radius = 1.0f;


        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            NextPoint();
    }
    private void NextPoint()
    {
        if (waypoints.Length == 0)
            return;

        agent.destination = waypoints[destPoint].position;

        
        destPoint = (destPoint + 1) % waypoints.Length;
    }
    private void StunnedMovement()
    {
        animator.SetBool("isStunned", true);
        agent.speed = 0;
        killSphere.radius = 0f;
    }
}
