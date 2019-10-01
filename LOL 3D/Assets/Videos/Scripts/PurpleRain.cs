using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleRain : MonoBehaviour
{
    [SerializeField] private GameObject rainStuff;

    private void ItsRainingStuff()
    {
        GameObject stuff = Instantiate(rainStuff, transform.position, transform.rotation);
    }
}
