using UnityEngine;

public class MeleePlayerAttack : PlayerAttack
{
    public LayerMask enemyMask;
    protected Collider2D enemy;

    public void CauseDamage()
    {
        if (enemy != null)
        {
            if (Vector2.Distance(enemy.transform.position, transform.position) <= attackRadius)
            {
                //enemy.GetComponent<EnemyKnockBack>().KnockBack(knockBackForce);
                enemy.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            enemy = null;
        }
    }

    protected override void Attack()
    {
        enemy = GetEnemy();
    }

    private Collider2D GetEnemy()
    {
        Vector2 attackDirection = mov.GetVectorDirection();
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyMask);

        foreach (var enemy in enemies)
        {
            Vector2 enemyDirection = (enemy.transform.position - transform.position).normalized;

            if (Vector2.Angle(attackDirection, enemyDirection) <= 45f)
                return enemy;
        }

        return null;
    }
}
