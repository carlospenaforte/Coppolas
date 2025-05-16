using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp;
    private int hp;

    private void Start()
    {
        hp = maxHp;
    }

    public void ChangeHealthPoints(int points)
    {
        hp += points;

        if (hp > maxHp)
        {
            hp = maxHp;
        }
        else if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }
    }
}
