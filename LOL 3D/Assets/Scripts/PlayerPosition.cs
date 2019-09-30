using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [HideInInspector] public static GameObject player;

    private void Start()
    {
        player = gameObject;
    }
}
