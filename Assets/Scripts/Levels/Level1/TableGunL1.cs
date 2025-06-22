using UnityEngine;

public class TableGunL1 : Event
{
    public GameObject gun, door;
    public Event table, decoder;

    private static bool destroyThemAll = false;

    private void Start()
    {
        controls = InputManager.GetInstance();
    }

    private void Update()
    {
        if (DecoderGunL1.GetGunUnlocked() && playerInside && controls.ActivateEvent() || destroyThemAll)
        {
            destroyThemAll = true;

            Destroy(gun);
            Destroy(door);
            Destroy(table.GetInstance());
            Destroy(decoder.GetInstance());
            Destroy(this);
        }
    }
}
