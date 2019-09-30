using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kazak : MonoBehaviour
{
    public float speed;
    public float rotationTimer;
    public float waitTimer;
    private bool isMoving;
    private Quaternion target;
    private float YRot;
    public float rotationSpeed;

    private void Start()
    {
        StartCoroutine("RandomRotation");
    }

    private void Update()
    {
        if (isMoving)
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator RandomRotation()
    {
        YRot = Random.Range(0, 360);
        target = Quaternion.Euler(0, YRot, 0);
        isMoving = true;
        yield return new WaitForSeconds(rotationTimer);
        isMoving = false;
        yield return new WaitForSeconds(waitTimer);
        StartCoroutine("RandomRotation");
    }
}
