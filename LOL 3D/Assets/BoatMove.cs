using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMove : MonoBehaviour
{
    [SerializeField] private float forwardForce;
    [SerializeField] private float rotationForce;

    private List<Rigidbody> rigidbodies = new List<Rigidbody>();
    [SerializeField] private Rigidbody gouvernail;

    private void Start()
    {
        CreateRigidBodyList();
    }

    private void CreateRigidBodyList()
    {
        foreach (var rigidBody in GetComponentsInChildren<Rigidbody>())
        {
            rigidbodies.Add(rigidBody);
        }
    }

    private void FixedUpdate()
    {
        MoveForward();
        Rotate();
    }


    private void MoveForward()
    {
        float forward = Input.GetAxis("Vertical");

        foreach (var body in rigidbodies)
        {
            body.AddRelativeForce(gameObject.transform.forward * forwardForce * forward, ForceMode.Acceleration);
        }

    }

    private void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal");

        gouvernail.AddForce(gouvernail.gameObject.transform.right * -rotation * rotationForce, ForceMode.Acceleration);
    }
}
