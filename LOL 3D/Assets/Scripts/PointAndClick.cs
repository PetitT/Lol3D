using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointAndClick : MonoBehaviour
{
    private NavMeshAgent nav;


    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move(Input.mousePosition);
        }

    }

    private void Move(Vector3 mousePos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        if (Physics.Raycast(ray, out hit))
            nav.destination = hit.point;
    }
}
