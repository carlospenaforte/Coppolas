using UnityEngine;

public class TableGunL1 : Event
{
    public GameObject gun, door;
    public NelcDialogueL1 antonDialogue;
    public Event table, decoder;

    private static bool destroyThemAll = false;

    protected override void ResetVariables()
    {
        destroyThemAll = false;
    }

    protected override void Awake()
    {
        base.Awake();

        if (destroyThemAll)
            DestroyThemAll();
    }

    private void Update()
    {
        if (DecoderGunL1.GetGunUnlocked() && playerInside && controls.ActivateEvent())
            DestroyThemAll();
    }

    private void DestroyThemAll()
    {
        Destroy(gun);
        Destroy(door);
        Destroy(table.GetInstance());
        Destroy(decoder.GetInstance());
        Destroy(this);

        if (!destroyThemAll)
            antonDialogue.StartWalking();

        destroyThemAll = true;
    }
}
