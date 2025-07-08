using UnityEngine;
using TMPro;

public abstract class InputEvent : Event
{
    public GameObject inputBoxPrefab;

    protected bool acepted = false, enterMode = false;
    protected float enterTimer = 0f, enterTime = 0.5f;
    protected string expectedText;
    protected TMP_InputField inputField;
    protected GameObject inputBox;

    protected abstract string AdjustText(string text);
    protected abstract string PrintErrorMessage();
    protected abstract string PrintMessage();
    protected abstract string GetExpectedText();

    protected override void Start()
    {
        base.Start();

        talkTime = 0.1f;
        expectedText = GetExpectedText();
        inputBox = Instantiate(inputBoxPrefab);
        inputField = inputBox.GetComponentInChildren<TMP_InputField>();
        inputBox.SetActive(false);
    }

    protected virtual void Update()
    {
        if (playerInside && controls.ActivateEvent() && timer <= 0f || activateEvent)
        {
            enterMode = true;
            activateEvent = false;
            timer = talkTime;
            controls.Enable("event");
            inputBox.SetActive(true);
        }
        else if (playerInside && controls.IsInteracting() && timer <= 0f && enterMode)
        {
            timer = talkTime;
            InteractEnterMode();
        }
        else if (playerInside && controls.IsInteracting() && timer <= 0f && !enterMode)
        {
            timer = talkTime;
            FinishEvent();
        }
        else
        {
            timer -= Time.deltaTime;
            enterTimer -= Time.deltaTime;
        }
    }

    protected virtual void FinishEvent()
    {
        inputField.interactable = true;
        controls.Enable("gameplay");
        inputBox.SetActive(false);
        inputField.text = "";
    }

    protected void InteractEnterMode()
    {
        if (enterTimer >= 0f)
        {
            enterMode = false;
            inputField.interactable = false;
            timer = talkTime;
            ShowFinalMessage();
        }
        else
        {
            inputField.text += "\n";
            enterTimer = enterTime;
        }
    }

    protected void ShowFinalMessage()
    {
        string text = AdjustText(inputField.text);

        if (!acepted)
            acepted = text == expectedText;

        inputField.text = acepted ? PrintMessage() : PrintErrorMessage();
    }
}
