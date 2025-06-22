using UnityEngine;
using TMPro;

public abstract class TextEvent : Event
{
    public GameObject dialogueBoxPrefab;
    protected GameObject box;
    protected TextMeshProUGUI dialogue;

    protected abstract string GetDialogueText();

    protected void Start()
    {
        talkTime = 0.25f;
        controls = InputManager.GetInstance();
        box = Instantiate(dialogueBoxPrefab);
        box.SetActive(false);
        dialogue = box.GetComponentInChildren<TextMeshProUGUI>();
        dialogue.text = GetDialogueText();
    }

    protected void Update()
    {
        if (playerInside && controls.ActivateEvent() && timer <= 0f)
        {
            timer = talkTime;
            controls.Enable("event");
            box.SetActive(true);
        }
        else if (playerInside && controls.IsInteracting() && timer <= 0f)
        {
            timer = talkTime;
            controls.Enable("gameplay");
            box.SetActive(false);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
