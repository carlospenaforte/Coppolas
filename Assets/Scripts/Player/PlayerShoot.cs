using UnityEngine;

public class PlayerShoot : PlayerAttack
{
    public int bulletLifeTime;
    public Transform prefabBullet;

    protected override void Attack()
    {
        Vector2 direction = mov.GetVectorDirection(), pos = rb.position + direction * attackRadius;
        Transform bullet = Instantiate(prefabBullet, pos, Quaternion.identity);
        Destroy(bullet.gameObject, bulletLifeTime);

        bullet.GetComponent<Bullet>().Configure(damage, knockBackForce, direction);
    }
}
