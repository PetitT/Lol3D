using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeSearch : MonoBehaviour
{
    public float spotRadius;
    public float spotDistance;
    public LayerMask layerMask;
    private Eye eye;

    private void Start()
    {
        eye = GetComponent<Eye>();
    }

    private void Update()
    {
        if (eye.isSearching)
            Search();
    }

    private void Search()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, spotRadius, transform.forward, out hit, spotDistance, layerMask))
        {
            eye.target = hit.collider.gameObject;
            eye.StartFollowing();
        }
    }
}
