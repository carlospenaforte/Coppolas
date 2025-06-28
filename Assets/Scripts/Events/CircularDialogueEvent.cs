public class CircularDialogueEvent : DialogueEvent
{
    protected override void Talk()
    {
        if (i == 0)
        {
            controls.Enable("event");
            box.SetActive(true);
        }
        else if (i == limit)
        {
            controls.Enable("gameplay");
            box.SetActive(false);
            i = 0;
            return;
        }

        dialogue.text = characters[i] + scripts[i];
        timer = talkTime;
        ++i;
    }
}
