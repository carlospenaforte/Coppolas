public class SingleDialogueEvent : DialogueEvent
{
    protected override void Talk()
    {
        if (i == 0)
        {
            controls.Enable("event");
            box.SetActive(true);
            activateEvent = false;
        }
        else if (i == limit)
        {
            controls.Enable("gameplay");
            Destroy(box);
            Destroy(this);
            return;
        }

        dialogue.text = characters[i] + scripts[i];
        timer = talkTime;
        ++i;
    }
}
