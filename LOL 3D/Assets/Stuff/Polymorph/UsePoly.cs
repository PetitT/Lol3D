using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsePoly : MonoBehaviour
{
    public Poly_Base[] poly_Bases;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            foreach (var item in poly_Bases)
            {
                item.ChangeColor();
            }
    }
}
