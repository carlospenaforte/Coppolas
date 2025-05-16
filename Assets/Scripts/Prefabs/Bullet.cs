using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;

    private int damage = 0, knockBackForce = 1;
    private Vector2 velocity = Vector2.zero;

    private void Update()
    {
        rb.linearVelocity = velocity;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<EnemyKnockBack>().KnockBack(knockBackForce);
            collider.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    public void Configure(int damage, int knockBackForce, Vector2 direction)
    {
        this.damage = damage;
        this.knockBackForce = knockBackForce;
        this.velocity = direction * speed;
    }
}
