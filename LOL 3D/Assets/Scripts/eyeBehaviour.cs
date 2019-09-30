using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class eyeBehaviour : MonoBehaviour
{
    public float spotRadius;
    public float deSpotRadius;

    private GameObject target;
    private NavMeshAgent nav;

    public float slowSpeed;
    public float slowRotation;
    private Quaternion targetRotation;
    public float timeToRotate;
    private float remainingTimeToRotate;

    public float followSpeed;
    public float maxDistanceDelta;

    public float attackDistance;

    private AudioSource audioSource;
    public AudioClip reeee;

    public float fleeSpeed;
    public float fleeTime;

    enum State { Search, Follow, Attack, Flee };

    State currentState;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentState = State.Search;
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        switch (currentState)
        {
            case State.Search:
                Walk();
                Search();
                NewRotationTimer();
                break;
            case State.Follow:
                Follow();
                DistanceCheck();
                break;
            case State.Attack:
                break;
            case State.Flee:                
                Flee(CalculateFleeDestination());
                DistanceCheck();
                break;
            default:
                break;
        }
    }

    #region SearchMethods
    private void Search()
    {
        RaycastHit hit;

        if (Physics.SphereCast(gameObject.transform.position, spotRadius, Vector3.forward, out hit))
            if (hit.collider.tag == "Player")
            {
                target = hit.collider.gameObject;
                currentState = State.Follow;
            }

    }

    private void Walk()
    {
        gameObject.transform.Translate(Vector3.forward * slowSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, slowRotation * Time.deltaTime);
    }

    private void NewRotationTimer()
    {
        remainingTimeToRotate += Time.deltaTime;
        if (remainingTimeToRotate >= timeToRotate)
        {
            remainingTimeToRotate = 0f;
            NewRotation();
        }
    }

    private void NewRotation()
    {
        float YRot = Random.Range(0, 360);
        targetRotation = Quaternion.Euler(0, YRot, 0);
    }

    #endregion

    #region FollowMethods
    private void Follow()
    {
        nav.destination = target.transform.position;
    }

    private void DistanceCheck()
    {

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance >= deSpotRadius)
        {
            Debug.Log("Stop Following");
            nav.destination = Vector3.zero;
            currentState = State.Search;
        }

        if (distance <= attackDistance)
        {
            AttackSound();
            nav.destination = Vector3.zero;
            currentState = State.Flee;
            StartCoroutine("FleeTimer");
        }

    }
    #endregion

    #region AttackMethods

    private void AttackSound()
    {
        audioSource.PlayOneShot(reeee);
    }

    #endregion

    #region FleeMethods
    private Vector3 CalculateFleeDestination()
    {
        Vector3 fleeDestination = (transform.position - target.transform.position);
        return fleeDestination;
    }

    private void Flee(Vector3 direction)
    {
        transform.Translate(direction * fleeSpeed * Time.deltaTime);
    }

    private IEnumerator FleeTimer()
    {
        yield return new WaitForSeconds(fleeTime);
        if (currentState == State.Flee)
            currentState = State.Search;
    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ArenaBoundary")
            NewRotation();
    }


}
