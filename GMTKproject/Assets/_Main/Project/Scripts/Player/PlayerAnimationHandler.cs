using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    //Little Mouse Anims
    public void PlayRunAnimation(float velocity)
    {
        _animator.SetFloat("Velocity", velocity);
    }
    
    //Mutant Mouse Anims
    
}