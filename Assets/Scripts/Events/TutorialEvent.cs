using UnityEngine;
using TMPro;

public abstract class TutorialEvent : Event
{
    public GameObject dialogueBoxPrefab, obj;

    protected int i = 0, limit;
    protected string[] messages;
    protected GameObject box;
    protected TextMeshProUGUI dialogue;

    protected abstract string[] GetMessages();

    protected override void Start()
    {
        base.Start();

        talkTime = 0.25f;
        messages = GetMessages();
        limit = messages.Length;
        box = Instantiate(dialogueBoxPrefab);
        dialogue = box.GetComponentInChildren<TextMeshProUGUI>();

        controls.Enable("event");
        ShowTutorialMessage();
    }

    protected void Update()
    {
        if (playerInside && controls.IsInteracting() && timer <= 0f)
            ShowTutorialMessage();
        else
            timer -= Time.deltaTime;
    }

    protected void ShowTutorialMessage()
    {
        if (i == limit)
        {
            controls.Enable("gameplay");
            Destroy(box);
            Destroy(obj);
            return;
        }

        dialogue.text = messages[i];
        timer = talkTime;
        ++i;
    }
}
