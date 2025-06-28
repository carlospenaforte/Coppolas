using UnityEngine;

public class TutorialEvent : SingleDialogueEvent
{
    public GameObject obj;
    private static bool destroyInstance = false;

    private void Awake()
    {
        if (destroyInstance)
            Destroy(obj);
    }

    protected override void Start()
    {
        base.Start();
        Talk();

        destroyInstance = true;
    }
}
