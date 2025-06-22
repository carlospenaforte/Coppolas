using UnityEngine;
using System.Linq;

public abstract class Event : MonoBehaviour
{
    protected bool playerInside = false;
    protected float timer = 0f, talkTime;
    protected InputManager controls;

    protected void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            playerInside = true;
    }

    protected void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
            playerInside = false;
    }

    public Event GetInstance()
    {
        return this;
    }
}
