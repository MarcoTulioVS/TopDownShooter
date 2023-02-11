using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    public static AnimationPlayerController instance;
    private Animator anim;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }
    
    public void ExecuteAnimation(AnimationStates animationStates)
    {
        anim.SetInteger("transition", (int)animationStates);
    }
}
