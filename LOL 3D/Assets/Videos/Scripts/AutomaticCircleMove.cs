using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticCircleMove : MonoBehaviour
{
    [SerializeField] private float timeCounter;
    [SerializeField] private float speed;
    [SerializeField] private float width;
    [SerializeField] private float height;

    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            timeCounter += Time.deltaTime * speed;
            float newX = Mathf.Cos(timeCounter) * width;
            float newY = Mathf.Sin(timeCounter) * height;
            float newZ = 10;

            transform.position = new Vector3(newX, newY, newZ);
        }

    }

    public void AutomaticMove()
    {
        isMoving = !isMoving;
    }
}
