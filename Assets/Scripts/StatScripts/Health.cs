using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : BaseStat
{


    public override void Moddify(int value)
    {
        currentAmmount += value;
    }
    public void changeMax(int value)
    {
        maxAmmount += value;
    }
 
}
