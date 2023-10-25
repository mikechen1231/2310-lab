using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navControl : MonoBehaviour
{
    public GameObject Target;
    private NavMeshAgent agent;
    private Animator animator;
    bool isWalking=true;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        agent.destination=Target.transform.position;
        else
        {
            agent.destination=transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="GoldBoarPBR")
        {
            isWalking=false;
            animator.SetTrigger("attacking");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name=="GoldBoarPBR")
        {
            isWalking=true;
            animator.SetTrigger("walking");
        }
    }
}
