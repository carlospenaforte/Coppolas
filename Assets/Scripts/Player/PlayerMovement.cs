using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    public Animator anim;

    private bool latestInputX = false, movementUnlocked = true;
    private float x, y;
    private string direction = "down";
    private InputManager controls;

    private void Start()
    {
        controls = InputManager.GetInstance();
    }

    private void Update()
    {
        if (movementUnlocked)
            Move();
    }

    private void Move()
    {
        int accelerator = controls.IsRunning() ? 2 : 1;
        x = controls.GetInputX();
        y = controls.GetInputY();

        AdjustCoordinates();

        anim.speed = accelerator;
        anim.SetBool("IsWalking", x != 0f || y != 0f);
        rb.linearVelocity = new Vector2(x, y) * speed * accelerator;
    }

    private void AdjustCoordinates()
    {
        if (x != 0f || y != 0f)
        {
            string oldDirection = direction;

            if (x != 0f && y != 0f && latestInputX)
                y = 0f;
            else if (x != 0f && y != 0f)
                x = 0f;
            else if (x != 0f)
                latestInputX = true;
            else
                latestInputX = false;

            if (x > 0f)
                direction = "right";
            else if (x < 0f)
                direction = "left";
            else if (y > 0f)
                direction = "up";
            else
                direction = "down";

            if (!oldDirection.Equals(direction))
                anim.Play("Idle " + direction);
        }
    }

    public void UnlockMovement()
    {
        movementUnlocked = true;
    }

    public void LockMovement()
    {
        movementUnlocked = false;
    }

    public string GetStrDirection()
    {
        return direction;
    }

    public Vector2 GetVetDirection()
    {
        switch (direction)
        {
            case "right": return Vector2.right;
            case "left": return Vector2.left;
            case "up": return Vector2.up;
            default: return Vector2.down;
        }
    }
}
