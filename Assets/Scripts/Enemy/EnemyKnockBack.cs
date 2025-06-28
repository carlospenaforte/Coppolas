using UnityEngine;

public class EnemyKnockBack : MonoBehaviour
{
    public float knockBackTime;
    public Rigidbody2D rb;
    public Animator anim;
    //public EnemyMovement mov;

    private float timer = 0f;

    private void Update()
    {
        /*if (timer <= 0f)
            mov.setKnockedBack(false);
        else
            timer -= Time.deltaTime;*/
    }

    public void KnockBack(int force)
    {
        //mov.setKnockedBack(true);
        timer = knockBackTime;
    }
}
