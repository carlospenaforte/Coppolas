using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;
    public Animator anim;

    private bool knockedBack;
    private Collider2D player;

    private void Update()
    {
        if (!knockedBack)
        {

        }
    }

    private void Move()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            player = collider;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && player == null)
            player = collider;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            player = null;
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void setKnockedBack(bool knockedBack)
    {
        this.knockedBack = knockedBack;
    }
}
