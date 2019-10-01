using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;

public class ActivateInterface : MonoBehaviour
{
    public List<IChangeColor> changeColors = new List<IChangeColor>();

    private void Start()
    {
        changeColors = FindObjectsOfType<MonoBehaviour>().OfType<IChangeColor>().ToList();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            ActivateStuff();
    }

    private void ActivateStuff()
    {
        foreach (var item in changeColors)
        {
            item.ChangeColor();
        }
    }
}
