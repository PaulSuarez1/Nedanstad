using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NedanstadRPG
{
    public class ItemDB : MonoBehaviour
    {
        public List<string> Items { get; set; } = new List<string>();
        public static ItemDB Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this.gameObject);
            else
                Instance = this;

            Items.Add("Sword of Fire");
            Items.Add("Shield of Rock");
            Items.Add("Bow of Wood");
        }

    }
}