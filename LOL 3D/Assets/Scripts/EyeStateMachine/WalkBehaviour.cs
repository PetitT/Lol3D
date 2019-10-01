using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkBehaviour : StateMachineBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;
    public float timeToRotate;
    private float remainingTimeToRotate;
    private Quaternion targetRotation;
    private GameObject eye;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Initialisation(animator);
    }

    private void Initialisation(Animator animator)
    {
        eye = animator.gameObject;
        remainingTimeToRotate = timeToRotate;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Walk();
        NewRotationTimer();
    }

    private void Walk()
    {
        eye.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        eye.transform.rotation = Quaternion.Slerp(eye.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void NewRotationTimer()
    {
        remainingTimeToRotate -= Time.deltaTime;
        if (remainingTimeToRotate <= 0)
        {
            remainingTimeToRotate = timeToRotate;
            NewRotation();
        }
    }

    private void NewRotation()
    {
        float YRot = Random.Range(0, 360);
        targetRotation = Quaternion.Euler(0, YRot, 0);
    }

}
