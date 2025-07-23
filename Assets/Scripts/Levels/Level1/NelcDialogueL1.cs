using UnityEngine;

public class NelcDialogueL1 : MonoBehaviour
{
    public GameObject anton;
    public SingleDialogueEvent dialogueBox;
    public Rigidbody2D rb;
    public Animator anim;
    public PlayerMovement mov;

    private bool destroyObject = false, firstLoop = false, thirdLoop = false, change = true;
    private InputManager controls;

    private void Awake()
    {
        controls = InputManager.GetInstance();
        StartWalking();
    }

    private void Update()
    {
        if (destroyObject)
            Destroy(anton);

        FirstLoop();
        SecondLoop();
        ThirdLoop();
    }

    private void FirstLoop()
    {
        if (firstLoop)
        {
            if (anton.transform.position.y < 4)
            {
                rb.linearVelocity = Vector2.up * 8;
            }
            else if (anton.transform.position.x > -2.5f)
            {
                if (change)
                {
                    anim.Play("Walk left");
                    change = false;
                }

                rb.linearVelocity = Vector2.left * 8;
            }
            else if (anton.transform.position.y < 7.5f)
            {
                if (!change)
                {
                    anim.Play("Walk up");
                    change = true;
                }

                rb.linearVelocity = Vector2.up * 8;
            }
            else
            {
                firstLoop = false;
                anim.SetBool("IsWalking", false);
                anim.Play("Idle down");
                dialogueBox.SetActivateEvent(true);
            }
        }
    }

    private void SecondLoop()
    {
        if (dialogueBox == null && !thirdLoop)
        {
            thirdLoop = true;
            anim.SetBool("IsWalking", true);
            anim.Play("Walk down");
        }
    }

    private void ThirdLoop()
    {
        if (thirdLoop)
        {
            if (anton.transform.position.y > 4)
            {
                rb.linearVelocity = Vector2.down * 8;
            }
            else if (anton.transform.position.x < 0)
            {
                if (change)
                {
                    anim.Play("Walk right");
                    change = false;
                }

                rb.linearVelocity = Vector2.right * 8;
            }
            else if (anton.transform.position.y > 0)
            {
                if (!change)
                {
                    anim.Play("Walk down");
                    change = true;
                }

                rb.linearVelocity = Vector2.down * 8;
            }
            else
            {
                controls.Enable("gameplay");
                mov.UnlockMovement();
                destroyObject = true;
            }
        }
    }

    public void StartWalking()
    {
        anton.SetActive(true);
        firstLoop = true;
        anim.SetBool("IsWalking", true);
        anim.Play("Walk up");
        controls.Enable("disable");
    }
}
