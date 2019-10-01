using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }
}
