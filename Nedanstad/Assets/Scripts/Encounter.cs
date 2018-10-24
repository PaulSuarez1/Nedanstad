using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NedanstadRPG
{

    public class Encounter : MonoBehaviour
    {
        public Enemy Enemy { get; set; }

        [SerializeField] Player player;

        [SerializeField] Button[] dynamicControls;

        public delegate void OnEnemyDieHandler();
        public static OnEnemyDieHandler OnEnemyDie;

        private void Start()
        {
            OnEnemyDie += Loot;
        }

        public void ResetDynamicControls()
        {
            foreach(Button Button in dynamicControls)
            {
                Button.interactable = false;
            }
        }

        public void StartCombat()
        {
            this.Enemy = player.Room.Enemy;
            dynamicControls[0].interactable = true;
            dynamicControls[1].interactable = true;
        }

        public void StartChest()
        {
            dynamicControls[3].interactable = true;
        }

        public void StartExit()
        {
            dynamicControls[2].interactable = true;
        }

        public void OpenChest()
        {
            Chest chest = player.Room.Chest;
            if (chest.Trap)
            {
                player.TakeDamage(5);
                Journal.Instance.Log("Ouch! It's a Trap! You took 5 damage. Your health is now at " + player.Energy);
            }
            else if (chest.Heal)
            {
                player.TakeDamage(-10);
                Journal.Instance.Log("Wow, that feels good! 10 points of healing puts your health at " + player.Energy);
            }
            else if (chest.Enemy)
            {
                player.Room.Enemy = chest.Enemy;
                player.Room.Chest = null;
                Journal.Instance.Log("The Chest contained a monster! Get it or it'll get you!");
                player.Investigate();

            }
            else
            {
                player.Gold += chest.Gold;
                player.AddItem(chest.Item);
                Journal.Instance.Log("You found: " + chest.Item + " and <color=#FFE556FF>" + chest.Gold + "g.</color>");
            }
            player.Room.Chest = null;
            dynamicControls[3].interactable = false;
        }

        public void Attack()
        {
            int playerDamageAmount = (int)(Random.value * (player.Attack - Enemy.Defence));
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - player.Defence));
            Journal.Instance.Log("<color=#59ffa1>You attacked, dealing <b>" + playerDamageAmount + "</b> damage!</color>");
            Journal.Instance.Log("<color=#59ffa1>The " + Enemy.Name + " attacked, dealing <b>" + enemyDamageAmount + "</b> damage!</color>");
            player.TakeDamage(enemyDamageAmount);
            Enemy.TakeDamage(playerDamageAmount);
        }

        public void Flee()
        {
            int enemyDamageAmount = (int)(Random.value * (Enemy.Attack - (player.Defence*.5f)));
            player.Room.Enemy = null;
            player.TakeDamage(enemyDamageAmount);
            Journal.Instance.Log("<color=#59ffa1>You cast Warp and flee from the room. However, the experience was painful and inflicted <b>" + enemyDamageAmount + "</b> damage.</color>");
            player.Investigate();
        }

        public void ExitFloor()
        {
            StartCoroutine(player.world.GenerateFloor());
            player.Floor += 1;
            Journal.Instance.Log("You found the entrance to the next floor! Floor: " + player.Floor);
            
        }

        public void Loot()
        {
            player.AddItem(this.Enemy.Inventory[0]);
            player.Gold += this.Enemy.Gold;
            Journal.Instance.Log(string.Format(
                "<color=#56FFC7FF>You've slain {0}! Searching the carcass, you find a {1} and {2} gold!</color>",
                this.Enemy.Name, this.Enemy.Inventory[0], this.Enemy.Gold
                ));
            player.Room.Enemy = null;
            player.Room.Empty = true;
            player.Investigate();
        }
    }
}