using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    [SerializeField] private float upwardForce;
    private bool isInWater = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = false;
            rb.drag = 0.05f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isInWater = true;
            rb.drag = 5f;
        }
    }

    private void FixedUpdate()
    {
        if (isInWater)
        {
            Vector3 force = transform.up * upwardForce;
            rb.AddRelativeForce(force, ForceMode.Acceleration);
        }
    }
}
