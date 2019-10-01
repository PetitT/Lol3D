using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceFifth : MonoBehaviour, IMove
{
    public bool canMove { get; set; }

    public void Movement()
    {
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
            gameObject.transform.Translate(Vector3.up * 15 * Time.deltaTime);
    }
}
