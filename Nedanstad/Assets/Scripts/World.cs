﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NedanstadRPG
{
    // Dungeon level is in this class
    public class World : MonoBehaviour
    {

        public Room[,] Dungeon { get; set; }
        public Vector2 Grid;
        private void Awake()
        {
            Dungeon = new Room[(int)Grid.x, (int)Grid.y];
            StartCoroutine(GenerateFloor());
        }

        public IEnumerator GenerateFloor()
        {
            Debug.Log("Generating floor!");
            for(int x = 0; x < Grid.x; x++)
            {
                for (int y = 0; y < Grid.x; y++)
                {
                    Dungeon[x, y] = new Room
                    {
                        RoomIndex = new Vector2(x, y)
                    };
                }
            }
            Debug.Log("Locating exists... ");
            yield return new WaitForEndOfFrame();

            Vector2 exitLocation = new Vector2((int)Random.Range(0, Grid.x), (int)Random.Range(0, Grid.y));
            Dungeon[(int)exitLocation.x, (int)exitLocation.y].Exit = true;
            Dungeon[(int)exitLocation.x, (int)exitLocation.y].Empty = false;
            Debug.Log("Exit is at: " + exitLocation);

        }


    }
}
