﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poly_Red : Poly_Base
{
    public override void ChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
