using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastsBoi : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.forward, out hit))
                if (hit.collider.tag == "oboi")
                    Debug.Log("Oboi");
        }

    }
}
