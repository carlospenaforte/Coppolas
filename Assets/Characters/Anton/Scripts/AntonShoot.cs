using UnityEngine;

public class AntonShoot : PlayerShoot
{
    private float xAdditional, yAdditional;

    protected override void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        xAdditional = sr.bounds.size.x / 4f;
        yAdditional = sr.bounds.size.y / 4f;
        controls = InputManager.GetInstance();
    }

    protected override void Attack()
    {
        Vector2 direction = mov.GetVectorDirection(), pos = rb.position + direction * attackRadius;

        pos += AdjustAdditionalCoordinates();

        Transform bullet = Instantiate(prefabBullet, pos, Quaternion.identity);
        Destroy(bullet.gameObject, bulletLifeTime);
        bullet.GetComponent<Bullet>().Configure(damage, knockBackForce, direction);
    }

    private Vector2 AdjustAdditionalCoordinates()
    {
        float x = 0f, y = 0f;
        string direction = mov.GetStrDirection();

        if (direction == "right")
            y = -yAdditional;
        else if (direction == "left")
            y = yAdditional;
        else if (direction == "up")
            x = xAdditional;
        else
            x = -xAdditional;

        return new Vector2(x, y);
    }
}
