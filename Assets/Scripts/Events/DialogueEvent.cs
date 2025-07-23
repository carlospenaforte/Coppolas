using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class DialogueEvent : Event
{
    public string directory;
    public GameObject dialogueBoxPrefab;

    protected int i = 0, limit;
    protected string[] characters, scripts;
    protected GameObject box;
    protected TextMeshProUGUI dialogue;

    protected abstract void Talk();

    protected override void Start()
    {
        base.Start();

        DialogueParser.LoadFromResources("Dialogues/" + directory);
        characters = DialogueParser.GetCharacters();
        scripts = DialogueParser.GetScripts();
        limit = characters.Length;

        talkTime = 0.25f;
        box = Instantiate(dialogueBoxPrefab);
        box.SetActive(false);
        dialogue = box.GetComponentInChildren<TextMeshProUGUI>();
    }

    protected void Update()
    {
        if (playerInside && (controls.ActivateEvent() || controls.IsInteracting()) && timer <= 0f || activateEvent)
            Talk();
        else
            timer -= Time.deltaTime;
    }
}
