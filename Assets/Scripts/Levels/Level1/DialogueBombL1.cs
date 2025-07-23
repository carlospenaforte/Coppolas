using UnityEngine;

public class DialogueBombL1 : SingleDialogueEvent
{
    private static bool destroyInstance = false;
    public Animator antonAnim, craigAnim;
    public AntonDetonatorL1 detonator;
    public PlayerMovement mov;

    protected override void Awake()
    {
        base.Awake();

        if (destroyInstance)
        {
            detonator.enabled = true;
            Destroy(this);
        }
    }

    protected override void ResetVariables()
    {
        destroyInstance = false;
    }

    protected override void Talk()
    {
        mov.LockMovement();

        if (i == limit)
        {
            mov.UnlockMovement();
            destroyInstance = true;
            detonator.enabled = true;
        }
        else if (characters[i] == "ANTON: ")
        {
            antonAnim.SetBool("IsWalking", true);
            craigAnim.SetBool("IsWalking", false);
        }
        else
        {
            antonAnim.SetBool("IsWalking", false);
            craigAnim.SetBool("IsWalking", true);
        }

        base.Talk();
    }
}
