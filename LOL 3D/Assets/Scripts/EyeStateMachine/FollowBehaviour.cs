using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowBehaviour : StateMachineBehaviour
{
    public float distanceToAttack;
    public float distanceToDesaggro;
    private Transform eye;
    private GameObject target;
    private NavMeshAgent nav;
    private Animator anim;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Initialisation(animator);
        Debug.Log("Follow State Enter");
    }

    private void Initialisation(Animator animator)
    {
        anim = animator;
        eye = animator.gameObject.transform;
        target = PlayerPosition.player;
        nav = animator.GetComponent<NavMeshAgent>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        DistanceCheck();
        Follow();
    }

    private void DistanceCheck()
    {
        float distance = Vector3.Distance(eye.position, target.transform.position);

        if (distance >= distanceToDesaggro)
        {
            nav.destination = Vector3.zero;
            anim.SetTrigger("Search");
        }

        if (distance <= distanceToAttack)
        {
            anim.SetTrigger("Attack");
        }
    }

    private void Follow()
    {
        nav.destination = target.transform.position;
    }
}
