using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform center;
    private bool isMoving;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        cam.transform.LookAt(center);

        if (isMoving)
            cam.transform.Translate(Vector3.right);
    }

    public void YouSpinMeRightRoundBabyRightRound()
    {
        isMoving = !isMoving;
    }
}
