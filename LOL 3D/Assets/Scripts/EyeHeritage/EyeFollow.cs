using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFollow : MonoBehaviour
{
    public float desAggroRadius;
    public float attackDistance;
    private Eye eye;

    private void Start()
    {
        eye = GetComponent<Eye>();
    }

    void Update()
    {
        if (eye.isFollowing)
            DistanceCheck();
    }

    private void DistanceCheck()
    {
        float distance = Vector3.Distance(transform.position, eye.target.transform.position);

        if (distance >= desAggroRadius)
        {
            eye.nav.destination = Vector3.zero;
            eye.StopFollowing();
        }

        if (distance <= attackDistance)
        {
            eye.nav.destination = Vector3.zero;
        }
    }
}
