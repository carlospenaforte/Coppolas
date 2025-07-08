using System;
using System.Linq;
using UnityEngine;

public class CodeShipL1 : InputEvent
{
    protected override void Start()
    {
        int[] coordinates = new int[3];

        for (int i = 0; i < 3; i++)
            coordinates[i] = AntonNPCL1.GetCoordinate(i);

        base.Start();
        expectedText = $"defmover_nave():returnx,y,zx={coordinates[0]}y={coordinates[1]}z={coordinates[2]}";
    }

    protected override void FinishEvent()
    {
        base.FinishEvent();

        if (acepted)
            Application.Quit();
    }

    protected override string AdjustText(string text)
    {
        string[] lines = text.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

        if (CheckCorrectFormatting(lines))
        {
            lines[0] = CheckFunctionLine(lines[0].Trim());
            lines[4] = CheckReturnLine(lines[4].Trim());

            lines = lines.Select(line => line.Replace("\t", "").Replace("\r", "").Replace(" ", "")).ToArray();
            Array.Sort(lines);

            return string.Concat(lines);
        }

        return null;
    }

    private bool CheckCorrectFormatting(string[] lines)
    {
        if (lines.Length == 5)
        {
            int[] spaces = { 0, 0, 0, 0, 0 };

            for (int i = 0; i < 5; i++)
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

            return CheckCount(spaces);
        }

        return false;
    }

    private bool CheckCount(int[] spaces)
    {
        for (int i = 2; i < 5; i++)
        {
            if (spaces[i] != spaces[1])
                return false;
        }

        return spaces[0] < spaces[1];
    }

    private string CheckFunctionLine(string line)
    {
        string[] list = line.Split(new char[] { ' ', '(', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        if (list.Length > 1)
        {
            if (list[0] == "def" && list[1] == "mover_nave")
            {
                list[1] += "(";
                return string.Concat(list);
            }
        }

        return "";
    }

    private string CheckReturnLine(string line)
    {
        string[] list = line.Split(new char[] { ' ', ',', '\t', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        if (list.Length == 4)
        {
            if (list[0] == "return")
            {
                Array.Sort(list);
                list[1] += ",";
                list[2] += ",";

                return string.Concat(list);
            }
        }

        return "";
    }

    protected override string PrintMessage()
    {
        return "A nave decolou!";
    }

    protected override string PrintErrorMessage()
    {
        return "A nave não decolou!\n\n" +
               "def funcao(parametro1, parametro2, ..., parametroN):\n" +
               "\tvar1 = valor1\n" +
               "\tvar2 = valor2\n" +
               "\t(...)\n" +
               "\tvarN = valorN\n\n" +
               "\treturn var1, var2, ..., varN";
    }

    protected override string GetExpectedText()
    {
        return null;
    }
}
