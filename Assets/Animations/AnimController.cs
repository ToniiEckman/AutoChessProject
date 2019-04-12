using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{


    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        anim.SetTrigger("Attack");
        anim.SetTrigger("Idle");

    }
    public void PlayIdle()
    {
        anim.SetTrigger("Idle");
    }
}
