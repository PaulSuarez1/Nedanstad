using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NedanstadRPG;

public class Spooker : Enemy
{

    private void Start()
    {
        Energy = 10;
        Attack = 10;
        Defence = 1;
        Gold = 25;
        Name = "Spooker";
        Description = "The mere sight of these eight-legged monstrosities is enough to stop a man dead... in his tracks";
        Inventory.Add("Web");
    }

}

