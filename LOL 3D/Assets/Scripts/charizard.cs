using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charizard : MonoBehaviour
{
    public GameObject projectile;
    public float Time;

    private void Start()
    {
        StartCoroutine("Tir");
    }

    private IEnumerator Tir()
    {
        yield return new WaitForSeconds(Time);
        Instantiate(projectile, gameObject.transform.position, projectile.transform.rotation);
        StartCoroutine("Tir");
    }
}
