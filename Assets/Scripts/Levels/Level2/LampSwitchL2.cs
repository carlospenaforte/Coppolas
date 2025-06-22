using System;
using System.Linq;
using UnityEngine;

public class LampSwitchL2 : InputEvent
{
    protected override string AdjustText(string text)
    {
        string[] lines = text.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

        if (CheckCorrectFormatting(lines))
        {
            lines[0] = CheckFunctionLine(lines[0]);
            lines[1] = CheckLoopLine(lines[1]);

            lines = lines.Select(line => line.Replace("\t", "").Replace("\r", "").Replace(" ", "")).ToArray();

            return string.Concat(lines);
        }

        return null;
    }

    private bool CheckCorrectFormatting(string[] lines)
    {
        if (lines.Length == 3)
        {
            int[] spaces = { 0, 0, 0 };

            for (int i = 0; i < 3; i++)
            {
                foreach (var caractere in lines[i].ToCharArray())
                {
                    if (caractere == ' ')
                        ++spaces[i];
                    else if (caractere == '\t')
                        spaces[i] += 5;
                    else
                        break;
                }
            }

            return spaces[0] < spaces[1] && spaces[1] < spaces[2];
        }

        return false;
    }

    private string CheckFunctionLine(string line)
    {
        string[] list = line.Split(new char[] { ' ', '(', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        if (list.Length > 1)
        {
            if (list[0] == "def" && list[1] == "acender_luzes")
            {
                list[1] += "(";
                return string.Concat(list);
            }
        }

        return "";
    }

    private string CheckLoopLine(string line)
    {
        string[] list = line.Split(new char[] { ' ', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        if (list.Length > 2)
        {
            if (list[0] == "for" && list[1] == "i" && list[2] == "in")
                return string.Concat(list);
        }

        return "";
    }

    protected override string PrintMessage()
    {
        return "A luzes foram acesas";
    }

    protected override string PrintErrorMessage()
    {
        return "A luzes não foram acesas!\n\n" +
               "def funcao(lista):\n" +
               "\tfor i in range(len(lista)):\n" +
               "\t\tlista[i] = valor_booleano";
    }

    protected override string GetExpectedText()
    {
        return "defacender_luzes(luzes_ligadas):foriinrange(len(luzes_ligadas)):luzes_ligadas[i]=True";
    }
}
