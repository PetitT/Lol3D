using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewersActivator : MonoBehaviour
{
    [SerializeField] private DynamicViewers dynamicViewer;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hiku");
        dynamicViewer.Activate();
    }
}
