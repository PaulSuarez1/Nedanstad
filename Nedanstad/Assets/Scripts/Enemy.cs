using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NedanstadRPG;

public class Enemy : Character
{



    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        Debug.Log("An enemy is taking damage ");
    }

    public override void Die()
    {
        base.Die();
        Debug.Log("An enemy has been slain! ");
    }
}
