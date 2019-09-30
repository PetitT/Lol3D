using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>();
    public int frequency;
    private void Start()
    {
        InvokeRepeating("Spawn", frequency, frequency);
    }

    private void Spawn()
    {
        int index = Random.Range(0, 2);
        Instantiate(items[index], transform.position, new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
    }
}
