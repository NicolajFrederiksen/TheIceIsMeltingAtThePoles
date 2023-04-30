using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    private Animator C_Animator;
    // Start is called before the first frame update
    void Start()
    {
        C_Animator = GetComponent<Animator>();
    }


    public void CharacterDead()
    {
        C_Animator.SetTrigger("Dying");
    }

    public void RopeClimb()
    {
        C_Animator.SetTrigger("RopeClimb");
    }

    public void LandedPlatform() 
    {
        C_Animator.SetTrigger("Landed");
    }

    public void Winning()
    {
        C_Animator.SetTrigger("Dance");
    }
}