using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ActivateSecondInterface : MonoBehaviour
{
    public List<IMove> moves = new List<IMove>();

    private void Start()
    {
        moves = FindObjectsOfType<MonoBehaviour>().OfType<IMove>().ToList();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
            foreach (var move in moves)
            {
                move.Movement();
            }
    }
}
