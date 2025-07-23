using System.Collections.Generic;
using UnityEngine;

public class WalkingNelcL1 : SingleDialogueEvent
{
    public Animator antonAnimator, craigAnimator;
    public PlayerMovement mov;

    protected override void Talk()
    {
        mov.LockMovement();

        if (i == limit)
        {
            craigAnimator.SetBool("IsWalking", false);
        }
        else if (characters[i] == "ANTON: ")
        {
            antonAnimator.SetBool("IsWalking", true);
            craigAnimator.SetBool("IsWalking", false);
        }
        else
        {
            antonAnimator.SetBool("IsWalking", false);
            craigAnimator.SetBool("IsWalking", true);
        }

        base.Talk();
    }
}
