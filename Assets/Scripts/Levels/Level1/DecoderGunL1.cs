using UnityEngine;

public class DecoderGunL1 : InputEvent
{
    public GameObject laser;

    private static bool gunUnlocked = false;
    private string code;

    protected override void Awake()
    {
        base.Awake();

        if (gunUnlocked)
            Destroy(laser);
    }

    protected override void Start()
    {
        code = TablePapersL1.GetCode();
        base.Start();
    }

    protected override void ResetVariables()
    {
        gunUnlocked = false;
    }

    protected override string AdjustText(string text)
    {
        return text.Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace(" ", "");
    }

    protected override string PrintMessage()
    {
        Destroy(laser);
        gunUnlocked = true;

        return "Código correto!";
    }

    protected override string PrintErrorMessage()
    {
        return "Código incorreto!\n\n{digito_1}{digito_2}{digito_3}{digito_4}";
    }

    protected override string GetExpectedText()
    {
        return code;
    }

    public static bool GetGunUnlocked()
    {
        return gunUnlocked;
    }
}
