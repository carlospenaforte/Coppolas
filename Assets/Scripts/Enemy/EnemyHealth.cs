using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int hp;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp < 0)
            Destroy(gameObject);
    }
}
