using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTimer : MonoBehaviour
{
    public float attackCoolDown;
    private float remainingCoolDown;
    private bool canAttack = true;

    public bool CanAttack { get => canAttack; private set => canAttack = value; }

    private void Start()
    {
        remainingCoolDown = attackCoolDown;
    }

    private void Update()
    {
        CoolDown();
    }

    private void CoolDown()
    {
        remainingCoolDown -= Time.deltaTime;
        if (remainingCoolDown <= 0)
            ResetCoolDown();
    }

    private void ResetCoolDown()
    {
        remainingCoolDown = attackCoolDown;
        CanAttack = true;
    }
}
