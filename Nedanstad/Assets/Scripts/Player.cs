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
        AddItem("Fists!");
        AddItem("Rag Shirt");
        AddItem("Rag Pants");
        AddItem("Map");
    }

    public void AddItem(string item)
    {
        Journal.Instance.Log("You are alive with nothing but: " + item);
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
