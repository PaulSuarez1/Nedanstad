using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NedanstadRPG;

public class Player : Character
{
    public int Floor { get; set; }

    void Start()
    {
        Floor = 0;
        Energy = 100;
        Attack = 10;
        Defence = 5;
        Gold = 0;
        Inventory = new List<string>();
        RoomIndex = new Vector2(2,2);
    }

    public void AddItem(string item)
    {
        Inventory.Add(item);
    }

    public override void TakeDamage(int amount)
    {
        Debug.Log("You took damage");
        base.TakeDamage(amount);
    }

    public override void Die()
    {
        Debug.Log("You are dead...");
        base.Die();
    }

}
