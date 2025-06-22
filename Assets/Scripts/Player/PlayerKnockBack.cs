using UnityEngine;

public class PlayerKnockBack : MonoBehaviour
{
    private static bool knockedBack = false;
    private float timer = 0f;
    public float knockBackTime;
    public Rigidbody2D rb;
    public Animator anim;

    private Vector2 velocity;

    private void Update()
    {
        if (knockedBack)
        {
            rb.linearVelocity = velocity;

            if (timer <= 0f)
                knockedBack = false;
            else
                timer -= Time.deltaTime;
        }
    }

    public void KnockBack(float force, float x, float y)
    {
        velocity = new Vector2(transform.position.x - x, transform.position.y - y).normalized * force;
        timer = knockBackTime;
        anim.speed = 0f;
        knockedBack = true;
    }

    public static bool GetKnockedBack()
    {
        return knockedBack;
    }
}
