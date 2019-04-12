using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : ScriptableObject
{
    public string aName = "New Ability";
    public int range;
    public Sprite aSprite;
    

    public abstract void Initialize(GameObject obj, BoardTile Target);

    public abstract void TriggerAbility(BoardTile Target);
}
