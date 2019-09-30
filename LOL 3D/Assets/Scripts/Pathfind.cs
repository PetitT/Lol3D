using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfind : MonoBehaviour
{
    public Transform target;
    public Transform secondTarget;
    private NavMeshAgent navMeshAgent;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.destination = target.position;
        StartCoroutine("ChangeTarget");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ChangeTarget()
    {
        yield return new WaitForSeconds(13f);
        navMeshAgent.destination = secondTarget.position;
        StartCoroutine("RechangeTarget");
    }

    private IEnumerator RechangeTarget()
    {
        yield return new WaitForSeconds(13f);
        navMeshAgent.destination = target.position;
        StartCoroutine("ChangeTarget");
    }
}
