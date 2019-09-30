using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicMovement : MonoBehaviour
{

    private Rigidbody rb;
    private float XMove;
    private float ZMove;
    public float moveForce;
    public float rotationForce;
    public float jumpForce;
    private float ZRotation;
    private float Yrotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ZRotation = gameObject.transform.rotation.z;
        Yrotation = gameObject.transform.rotation.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        XMove = Input.GetAxisRaw("Horizontal") * rotationForce;
        ZMove = Input.GetAxisRaw("Vertical") * moveForce;

        ZRotation = 0;
        Yrotation = 0;

        if (Input.GetAxisRaw("Horizontal") == 0)
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        if (!Input.anyKey)
        {
            XMove = 0;
            ZMove = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddRelativeForce(transform.up * jumpForce * Time.deltaTime, ForceMode.Impulse);

        rb.AddRelativeForce(Vector3.forward * ZMove * Time.deltaTime);

        rb.AddTorque(transform.right * -XMove * 0.5f * Time.deltaTime);
    }
}
