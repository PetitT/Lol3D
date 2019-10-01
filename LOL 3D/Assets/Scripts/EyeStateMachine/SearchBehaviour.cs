using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBehaviour : StateMachineBehaviour
{
    private Transform eye;
    private GameObject target;
    private Animator anim;
    public LayerMask layerMask;
    public float spotDistance;
    public float spotRadius;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Initialisaiton(animator);
    }

    private void Initialisaiton(Animator animator)
    {
        eye = animator.gameObject.transform;
        anim = animator;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Search();
    }

    private void Search()
    {
        RaycastHit hit;
        if (Physics.SphereCast(eye.position, spotRadius, eye.forward, out hit, spotDistance, layerMask))
        {
            target = hit.collider.gameObject;
            StartFollowing();
        }
    }

    private void StartFollowing()
    {
        anim.SetTrigger("Follow");
    }
}
