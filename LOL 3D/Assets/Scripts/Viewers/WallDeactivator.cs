using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDeactivator : MonoBehaviour
{
    [SerializeField] private List<GameObject> wallsToDeactivate = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ToggleWalls();
        }
    }

    private void ToggleWalls()
    {
        foreach (var wall in wallsToDeactivate)
        {
            wall.SetActive(!wall.activeSelf);
        }
    }
}
