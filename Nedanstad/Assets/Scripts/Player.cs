using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NedanstadRPG;

public class Player : Character
{
    public int Floor { get; set; }
    public Room Room { get; set; }

    [SerializeField] Encounter encounter;
    [SerializeField] World world;

    void Start()
    {
        Floor = 0;
        Energy = 100;
        Attack = 10;
        Defence = 5;
        Gold = 0;
        Inventory = new List<string>();
        RoomIndex = new Vector2(2,2);
        this.Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];
        this.Room.Empty = true;

        AddItem("Fists!");
        AddItem("Rag Shirt");
        AddItem("Rag Pants");
        AddItem("Map");
    }

    public void Move(int direction)
    {
        if (this.Room.Enemy)
        {
            //return;
        }
        // North
        if (direction == 0 && RoomIndex.y > 0)
        {
            Journal.Instance.Log("You moved North.");
            RoomIndex -= Vector2.up;
        }
        // East
        if (direction == 1 && RoomIndex.x < world.Dungeon.GetLength(0)-1)
        {
            Journal.Instance.Log("You moved East.");
            RoomIndex += Vector2.right;
        }
        // South
        if (direction == 2 && RoomIndex.y < world.Dungeon.GetLength(1)-1)
        {
            Journal.Instance.Log("You moved South.");
            RoomIndex -= Vector2.down;
        }
        // West
        if (direction == 3 && RoomIndex.x > 0)
        {
            Journal.Instance.Log("You moved West.");
            RoomIndex += Vector2.left;
        }

        if (this.Room.RoomIndex != RoomIndex)
            Investigate();
    }

    public void Investigate()
    {
        this.Room = world.Dungeon[(int)RoomIndex.x, (int)RoomIndex.y];
        encounter.ResetDynamicControls();
        if (this.Room.Empty)
        {
            Journal.Instance.Log("There doesn't seem to be anything in here but a cold chill in the air...");
        }
        else if (this.Room.Chest != null)
        {
            Journal.Instance.Log("You found a chest! What would you like to do?");
        }
        else if (this.Room.Enemy != null)
        {
            Journal.Instance.Log("Out of the darkness appears a " + Room.Enemy.Name + "! What would you like to do?");
            encounter.StartCombat();
        }
        else if (this.Room.Exit)
        {
            Journal.Instance.Log("You made it to the exit for this floor! Are you ready to go to the next level?");
        }
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
