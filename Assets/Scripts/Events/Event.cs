using UnityEngine;
using System.Linq;

public abstract class Event : MonoBehaviour
{
    protected static bool resetVariables = false;
    protected bool playerInside = false, activateEvent = false;
    protected float timer = 0f, talkTime;
    protected InputManager controls;

    protected virtual void Awake()
    {
        if (resetVariables)
            ResetVariables();
    }

    protected virtual void Start()
    {
        controls = InputManager.GetInstance();
        resetVariables = false;
    }

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

    protected virtual void ResetVariables()
    {

    }

    public Event GetInstance()
    {
        return this;
    }

    public void SetActivateEvent(bool activateEvent)
    {
        this.activateEvent = activateEvent;
    }

    public static void SetResetVariables(bool resetVariables)
    {
        Event.resetVariables = resetVariables;
    }
}
