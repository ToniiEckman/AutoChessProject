using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStat : MonoBehaviour
{
    public int currentAmmount;
    public int maxAmmount;


    public abstract void Moddify(int value);
    
}
