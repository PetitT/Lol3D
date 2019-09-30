using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeNewRotation : MonoBehaviour
{
    private Eye eye;
    public float timeToRotate;
    void Start()
    {
        eye = GetComponent<Eye>();
        eye.remainingTimeToRotate = timeToRotate;
    }

    void Update()
    {
        if(eye.isSearching)
            NewRotationTimer();
    }

    private void NewRotationTimer()
    {
        eye.remainingTimeToRotate -= Time.deltaTime;
        if (eye.remainingTimeToRotate <= 0)
        {
            eye.remainingTimeToRotate = timeToRotate;
            NewRotation();
        }
    }

    private void NewRotation()
    {
        float YRot = Random.Range(0, 360);
        eye.targetRotation = Quaternion.Euler(0, YRot, 0);
    }

}
