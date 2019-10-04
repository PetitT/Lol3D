using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicViewers : MonoBehaviour
{
    [SerializeField] private List<GameObject> viewers = new List<GameObject>();

    private bool isActive = false;


    public int IsActive
    {
        get { return IsActive; }
        set { IsActive = value;}
    }

    private void Toggle()
    {
        foreach (var wall in viewers)
        {
            wall.SetActive(isActive);
        }
    }

    public void Activate()
    {
        isActive = !isActive;
        Toggle();
    }


}
