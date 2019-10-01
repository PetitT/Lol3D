using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceSecond : MonoBehaviour, IChangeColor
{
    public Color color { get; set; } = Color.black;

    public void ChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
