using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneAI : MonoBehaviour
{

    Transform Target;
    NavMeshAgent Agent;
    Animator Anim;
    bool IsDead = false;

    // Use this for initialization
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Target.position);

        if (distance > 15 && !IsDead)
        {
            Agent.updatePosition = true;
            Agent.SetDestination(Target.position);
            Anim.SetBool("StartMoving", true);
            Anim.SetBool("IsStopping", false);
            Anim.SetBool("Stopped", false);
        }
        else
        {
            Agent.updatePosition = false;
            Anim.SetBool("StartMoving", false);
            Anim.SetBool("IsStopping", true);
            Anim.SetBool("Stopped", false);
        }



    }
    public void EnemyDeathAnim()
    {
        IsDead = true;
        Anim.SetTrigger("IsDead");
    }
}
