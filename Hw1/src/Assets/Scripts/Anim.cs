using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    private Animator anim;   

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void WalkAnimation()
    {
        anim.Play("Walk", -1, 0f);
    }

    public void KnockOutAnimation()
    {
        anim.Play("Knock Out", -1, 0f);
    }

    public void GetHitAnimation()
    {
        anim.Play("Get Hit", -1, 0f);
    }

    public void CoverAnimation()
    {
        anim.Play("Cover", -1, 0f);
    }

    public void DeathAnimation()
    {
        anim.Play("Death", -1, 0f);
    }

    public void Attack1Animation()
    {
        anim.Play("Attack_01", -1, 0f);
    }

    public void Attack2Animation()
    {
        anim.Play("Attack_02", -1, 0f);
    }

}

