using System.Linq;

public class BombMakerL1 : InputEvent
{
    private static bool bombMaked = false;
    private static int indexDetonador;
    private static string myBomb;

    protected override void Update()
    {
        if (!bombMaked)
            bombMaked = acepted;

        base.Update();
    }

    protected override string AdjustText(string text)
    {
        text = text.Replace("\n", "").Replace("\t", "").Replace("\r", "").ToLower();

        char[] chars = { '\"', '\'', ',', '=', '[', ']' };
        string[] list = text.Split(new char[] { '\"', '\'' });
        string[] list2 = text.Split(chars).Where(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.Trim()).ToArray();

        if (list.Length == 11 && CheckSpaces(list2))
        {
            string[] items = { list[1], list[3], list[5], list[7], list[9] };

            for (int i = 0; i < 5; i++)
            {
                if (items[i] == "detonador" && !acepted)
                {
                    myBomb = text;
                    indexDetonador = i;
                }
            }

            System.Array.Sort(items);

            for (int i = 1; i < 11; i += 2)
                list[i] = "'" + items[(i - 1) / 2] + "'";

            return string.Concat(list).Replace(" ", "");
        }

        return null;
    }

    private bool CheckSpaces(string[] list)
    {
        string[] strs = { "bateria", "bobina", "bomba", "detonador", "gerador", "temporizador" };

        if (list.Length == 6)
        {
            System.Array.Sort(list);

            for (int i = 0; i < 6; i++)
            {
                if (list[i] != strs[i])
                    return false;
            }

            return true;
        }

        return false;
    }

    protected override void ResetVariables()
    {
        bombMaked = false;
    }

    protected override string PrintMessage()
    {
        return "Bomba fabricada!";
    }

    protected override string PrintErrorMessage()
    {
        return "Bomba não fabricada!\n\nlista = [item1, item2, ..., itemN]";
    }

    protected override string GetExpectedText()
    {
        return "bomba=['bateria','bobina','detonador','gerador','temporizador']";
    }

    public static bool GetBombMaked()
    {
        return bombMaked;
    }

    public static string GetMyBomb()
    {
        return myBomb;
    }

    public static int GetIndexDetonator()
    {
        return indexDetonador;
    }
}
