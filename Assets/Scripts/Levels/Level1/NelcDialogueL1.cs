using UnityEngine;

public class NelcDialogueL1 : MonoBehaviour
{
    public GameObject anton;
    public SingleDialogueEvent dialogueBox;
    public Rigidbody2D rb;
    public Animator anim;

    private static bool destroyObject = false;
    private bool firstLoop = false, thirdLoop = false;
    private InputManager controls;

    private void Awake()
    {
        if (destroyObject)
            Destroy(anton);

        controls = InputManager.GetInstance();
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
            else
            {
                firstLoop = false;
                anim.SetBool("IsWalking", false);
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
            if (anton.transform.position.y > -2)
            {
                rb.linearVelocity = Vector2.down * 8;
            }
            else
            {
                controls.Enable("gameplay");
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
