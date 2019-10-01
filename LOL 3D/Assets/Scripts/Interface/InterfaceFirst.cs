using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceFirst : MonoBehaviour, IChangeColor
{
    public Color color { get; set; } = Color.blue;

    public void ChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = color;
    }
}
