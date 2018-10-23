using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NedanstadRPG;

public class Rat : Enemy {

    private void Start()
    {
        Energy = 10;
        Attack = 5;
        Defence = 3;
        Gold = 20;
        Name = "Rat";
        Description = "Intelligent betrayers of their rodentkind; rats are employed by the dwarves to keep their dungeons secure.";
        Inventory.Add("Blood");
    }

}
