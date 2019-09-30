using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    public float moveSpeed;
    public float rotationSpeed;
    public float jumpSpeed;
    public float gravity;

    public Transform cam;

    private Vector3 moveDirection;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        //if (characterController.isGrounded)
        //{
        //    if (Input.GetButton("Jump"))
        //    {
        //        moveDirection.y = jumpSpeed;
        //    }
        //}

        //float Xmove = Input.GetAxis("Horizontal");
        //float Zmove = Input.GetAxis("Vertical");

        //moveDirection = new Vector3(Xmove, 0.0f, Zmove);
        //moveDirection *= speed;

        //moveDirection.y += Physics.gravity.y * Time.deltaTime;

        //characterController.Move(moveDirection * Time.deltaTime);

        //float moveHorizontal = -Input.GetAxisRaw("Horizontal");
        //float moveVertical = Input.GetAxisRaw("Vertical");


        //Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);

        //if (movement != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        //}

        //characterController.Move(movement);

        //transform.Translate(movement * speed * Time.deltaTime, Space.World);

        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotationSpeed, 0));
        Vector3 forward = Input.GetAxis("Vertical") * transform.forward * moveSpeed;

        characterController.Move(forward);

    }
}
