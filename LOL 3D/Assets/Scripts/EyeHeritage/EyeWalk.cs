using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeWalk : MonoBehaviour
{    
    public float moveSpeed;
    public float rotationSpeed;
    private Eye eye;

    private void Start()
    {
        eye = GetComponent<Eye>();
    }

    void Update()
    {
        if (eye.isSearching)
        {
            Walk();
        }
    }

    private void Walk()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, eye.targetRotation, rotationSpeed * Time.deltaTime);
    }
}
