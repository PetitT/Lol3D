using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceFourth : MonoBehaviour, IChangeColor
{
    public Color color { get; set; }

    public void ChangeColor()
    {
        StartCoroutine("RandomColor");
    }

    private IEnumerator RandomColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        yield return new WaitForSeconds(1);
        StartCoroutine("RandomColor");
    }
}
