using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NedanstadRPG
{
    public class EnemyDB : MonoBehaviour
    {
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
            public static EnemyDB Instance { get; set; }

        private void Awake()
        {
            Instance = this;

            foreach(Enemy enemy in GetComponents<Enemy>())
            {
                Debug.Log("Found enemy!");
                Enemies.Add(enemy);
            }
         
        }

        public Enemy GetRandomEnemy()
        {
            return Enemies[Random.Range(0, Enemies.Count)];
        }

    }


}
