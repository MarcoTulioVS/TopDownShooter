using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public static AnimationController instance;
    public Animator anim;

    private void Awake()
    {
        instance = this;
    }
    
    public void ExecuteAnimation(AnimationStates animationStates)
    {
        anim.SetInteger("transition", (int)animationStates);
    }
}
