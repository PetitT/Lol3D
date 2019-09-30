using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceThird : MonoBehaviour, IChangeColor, IMove
{
    public Color color { get; set; } = Color.yellow;
    public bool canMove { get; set; }

    public void ChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }

    public void Movement()
    {
        canMove = true;
    }

    private void Update()
    {
        if (canMove)
            gameObject.transform.Translate(Vector3.up * 5 * Time.deltaTime);
    }
}
