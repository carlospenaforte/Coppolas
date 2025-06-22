using UnityEngine;

public class DetonatorL1 : InputEvent
{
    private static bool doorExploded = false;

    protected override void Update()
    {
        if (BombMakerL1.GetBombMaked())
        {
            base.Update();
        }
    }

    protected override void FinishEvent()
    {
        inputField.interactable = true;
        controls.Enable("gameplay");
        inputBox.SetActive(false);
        inputField.text = "";

        if (acepted)
            doorExploded = true;
    }

    protected override string AdjustText(string text)
    {
        expectedText = BombMakerL1.GetIndexDetonator().ToString();
        return text.Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace(" ", "");
    }

    protected override string GetExpectedText()
    {
        return "∅";
    }

    protected override string PrintMessage()
    {
        return "A porta foi detonada!";
    }

    protected override string PrintErrorMessage()
    {
        return "A porta não foi detonada! Digite o índice da lista que representa o Detonador!";
    }

    public static bool GetDoorExploded()
    {
        return doorExploded;
    }
}
