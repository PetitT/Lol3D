using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ActivateSecondInterface : MonoBehaviour
{
    public List<IMove> moves = new List<IMove>();

    private void Start()
    {
        GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        foreach (var root in rootObjects)
        {
            moves.AddRange(root.GetComponentsInChildren<IMove>(true));
        }

       // moves = FindObjectsOfType<MonoBehaviour>().OfType<IMove>().ToList();
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
