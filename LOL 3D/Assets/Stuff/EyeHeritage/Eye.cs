using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Eye : MonoBehaviour
{
    [HideInInspector] public bool isSearching = true;
    [HideInInspector] public bool isFollowing = false;
    [HideInInspector] public float remainingTimeToRotate;
    [HideInInspector] public Quaternion targetRotation;
    [HideInInspector] public GameObject target;
    [HideInInspector] public NavMeshAgent nav;
    [HideInInspector] public AudioSource audioSrc;

    private void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        audioSrc = GetComponent<AudioSource>();
    }

    public void StartFollowing()
    {
        isSearching = false;
        isFollowing = true;
        nav.destination = target.transform.position;
    }

    public void StopFollowing()
    {
        isSearching = true;
        isFollowing = false;
        nav.destination = Vector3.zero;
    }
}
