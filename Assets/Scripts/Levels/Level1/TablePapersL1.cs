using UnityEngine;

public class TablePapersL1 : TextEvent
{
    private static int[] code = new int[4];
    private string text;

    protected override void Awake()
    {
        base.Awake();
        text = GetText1() + GetText2() + GetText3() + GetText4();
    }

    private string GetText1()
    {
        int a = Random.Range(7, 15), b = Random.Range(0, 8);
        string text = "Primeiro dígito: resultado de uma operação matemática\n" + "\n\ta = " + a + "\n\tb = "
                      + b + "\n\tdigito_1 = (a * 2 - b) // 3\n\n";

        code[0] = (a * 2 - b) / 3;

        return text;
    }

    private string GetText2()
    {
        int listIndex = Random.Range(0, 5);
        int[] list = { Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10) };
        string text = $"Segundo dígito: índice correto em uma lista\n\n\tlista = [{list[0]}";

        for (int i = 1; i < 5; i++)
            text += $", {list[i]}";

        text += $"]\n\tdigito_2 = lista[{listIndex}] // 2\n\n";
        code[1] = list[listIndex] / 2;

        return text;
    }

    private string GetText3()
    {
        int x = Random.Range(0, 9), y = Random.Range(0, 9);
        string text = $"Terceiro dígito: soma condicional\n\n\tx = {x}\n\ty = {y}\n\n\tif x < y:"
                      + "\n\t\tdigito_3 = x + 1\n\telse:\n\t\tdigito_3 = y + 1\n\n";

        code[2] = x < y ? x + 1 : y + 1;

        return text;
    }

    private string GetText4()
    {
        int num = Random.Range(3, 11);
        code[3] = (num * num + 5) % 10;

        return $"Quarto dígito: módulo\n\n\tdigito_4 = ({num}**2 + 5) % 10\n"; ;
    }

    public static string GetCode()
    {
        return $"{code[0]}{code[1]}{code[2]}{code[3]}";
    }

    protected override string GetDialogueText()
    {
        return text;
    }
}
