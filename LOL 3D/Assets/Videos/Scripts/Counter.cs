using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class Counter : MonoBehaviour
{
    private TextMeshPro tmp;
    private int counter = 0;

    private void Start()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    public void IncreaseScore()
    {
        counter++;
        tmp.text = counter.ToString();
    }
}
