using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Warrior_AI : MonoBehaviour {

    Transform Target;
    NavMeshAgent Agent;
    Animator Anim;
    bool IsDead = false;
    public bool CanAttack = true;
    [SerializeField]
    float ChaseDistance = 2f;
    [SerializeField]
    float TurnSpeed = 5f;
    public float DamageAmount = 35f;
    [SerializeField]
    float attackTime = 2f;

	// Use this for initialization
	void Start ()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(transform.position, Target.position);

        if (distance > ChaseDistance && !IsDead)
        {
            ChasePlayer();
        }
        else if(CanAttack)
        {
            AttackPlayer();
        }

       
	    }
    public void EnemyDeathAnim()
    {
        IsDead = true;
        Anim.SetTrigger("IsDead");
    }

    void ChasePlayer()
    {
        Agent.updateRotation = true;
        Agent.updatePosition = true;
        Agent.SetDestination(Target.position);
        Anim.SetBool("IsWalking", true);
        Anim.SetBool("IsAttacking", false);
    }

    void AttackPlayer()
    {
        Agent.updateRotation = false;
        Vector3 Direction = Target.position - transform.position;
        Direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), TurnSpeed * Time.deltaTime);
        Agent.updatePosition = false;
        Anim.SetBool("IsWalking", false);
        Anim.SetBool("IsAttacking", true);
    }

    IEnumerator AttackTime()
    {
        CanAttack = false;
        yield return new WaitForSeconds(0.5f);
        PlayerHealth.singleton.PlayerDamage(DamageAmount);
        yield return new WaitForSeconds(attackTime);
        CanAttack = true;
    }
}
