using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Ablity/melee")]
public class MeleeAbility : BaseAbility
{
    public int myDamage = -10;
    public GameObject hitBox;

    public int Range
    {
        get
        {
            return range;
        }

        set
        {
            range = value;
        }
    }

    public override void Initialize(GameObject obj, BoardTile Target)
    {
        hitBox.GetComponent<HitCube>().damage = myDamage;
        GameObject go = Instantiate(obj,new Vector3(Target.CurrentX,4,Target.CurrentZ),Quaternion.identity);
        
        Object.Destroy(go, 2.0f);
    }

    public override void TriggerAbility(BoardTile Target)
    {
        Initialize(hitBox, Target);
    }


}
