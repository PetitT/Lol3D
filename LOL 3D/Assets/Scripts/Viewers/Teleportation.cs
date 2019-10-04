using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private Transform teleportPosition;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            if (HasTeleported.hasTeleported == false)
            {
                other.gameObject.transform.position = teleportPosition.position;
               // other.gameObject.transform.rotation = teleportPosition.rotation;
                StartCoroutine("TeleportCoolDown");
            }
    }

    private IEnumerator TeleportCoolDown()
    {
        HasTeleported.hasTeleported = true;
        yield return new WaitForSeconds(HasTeleported.teleportCoolDown);
        HasTeleported.hasTeleported = false;
    }
}
