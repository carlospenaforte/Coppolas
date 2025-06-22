using System.Linq;

public class WeaponsBackpackL2 : InputEvent
{
    protected override string AdjustText(string text)
    {
        text = AdjustText(text.Replace("\n", "").Replace("\t", "").Replace("\r", "").ToLower());

        char[] chars = { '\"', '\'', ',', '=', '{', '}', ':' };
        string[] list = text.Split(new char[] { '\"', '\'' });
        string[] list2 = text.Split(chars).Where(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.Trim()).ToArray();

        if (list.Length == 13 && CheckSpaces(list2))
        {
            string[] items = { list[1], list[3], list[5], list[7], list[9], list[11] };
            Order(items);

            for (int i = 1; i < 13; i += 2)
                list[i] = "'" + items[(i - 1) / 2] + "'";

            return string.Concat(list).Replace(" ", "");
        }

        return null;
    }

    public bool CheckSpaces(string[] list)
    {
        string[] strs = { "balas", "cartucho", "cinto", "coldre", "granadas", "mochila", "revólver" };

        if (list.Length == 7)
        {
            System.Array.Sort(list);

            for (int i = 0; i < 7; i++)
            {
                if (list[i] != strs[i])
                    return false;
            }

            return true;
        }

        return false;
    }

    private void Order(string[] list)
    {
        bool exchange = false;
        string copy;

        do
        {
            exchange = false;

            for (int i = 0; i < 4; i += 2)
            {
                if (string.Compare(list[i], list[i + 2]) > 0)
                {
                    copy = list[i];
                    list[i] = list[i + 2];
                    list[i + 2] = copy;

                    copy = list[i + 1];
                    list[i + 1] = list[i + 3];
                    list[i + 3] = copy;

                    exchange = true;
                }
            }
        } while (exchange);
    }

    protected override string PrintMessage()
    {
        return "A mochila ficou pronta!";
    }

    protected override string PrintErrorMessage()
    {
        return "A mochila não ficou pronta!\n\ndicionario = { chave1: valor1, chave2: valor2, ..., chaveN: valorN }";
    }

    protected override string GetExpectedText()
    {
        return "mochila={'cartucho':'balas','cinto':'granadas','coldre':'revólver'}";
    }
}
