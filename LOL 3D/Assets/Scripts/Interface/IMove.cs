using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMove
{
    bool canMove { get; set; }

    void Movement();
}
