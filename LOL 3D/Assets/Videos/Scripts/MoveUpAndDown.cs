using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float lerpTime;

    public void Move()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
        gameObject.transform.position = Vector3.Slerp(transform.position, newPos, lerpTime);
        distance = distance * -1;
    }
}
