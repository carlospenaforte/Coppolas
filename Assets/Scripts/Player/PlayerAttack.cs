using UnityEngine;

public abstract class PlayerAttack : MonoBehaviour
{
    public int damage, knockBackForce;
    public float attackTime, attackRadius;
    public PlayerMovement mov;
    public Animator anim;
    public Rigidbody2D rb;

    protected float timer = 0f;
    protected InputManager controls;

    protected abstract void Attack();

    protected virtual void Start()
    {
        controls = InputManager.GetInstance();
    }

    protected void Update()
    {
        if (timer <= 0f && controls.IsAttacking() && !PlayerKnockBack.GetKnockedBack())
        {
            rb.linearVelocity = Vector2.zero;
            timer = attackTime;
            anim.speed = 1f;

            Attack();
            //mov.LockMovement();
            //anim.Play("Attack " + mov.GetStrDirection());
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
