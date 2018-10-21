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
        Inventory.Add("Web");
    }

}

