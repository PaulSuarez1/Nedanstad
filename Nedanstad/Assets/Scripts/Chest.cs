using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NedanstadRPG
{
    // creates random chests
    public class Chest
    {
        public string Item { get; set; }
        public int Gold { get; set; }
        public bool Trap { get; set; }
        public bool Heal { get; set; }
        public Enemy Enemy { get; set; }

        public Chest()
        {
            if (Random.Range(0, 7) == 2)
            {
                Trap = true;
            }
            else if (Random.Range(0, 5) == 2)
            {
                Heal = true;
            }
            else if (Random.Range(0, 5) == 2)
            {
                Enemy = EnemyDB.Instance.GetRandomEnemy();
            }
            else
            {
                int itemToAdd = Random.Range(0, ItemDB.Instance.Items.Count);
                Item = ItemDB.Instance.Items[itemToAdd];
                Gold = Random.Range(20, 200);
            }
        }


    }
}
