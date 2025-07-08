using System;
using System.Linq;
using UnityEngine;

public class FileUnforgivenL2 : InputEvent
{
    private string[] fileObjects = new string[2];

    protected override string AdjustText(string text)
    {
        string[] lines = text.Split('\n').Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

        fileObjects[0] = "φ";
        fileObjects[1] = "π";

        if (CheckCorrectFormatting(lines))
        {
            lines[0] = CheckWithOpenLine(lines[0]);
            lines[1] = CheckFunctionLine(lines[1]);

            if (fileObjects[0] == fileObjects[1])
                return lines[0] + lines[1];
        }

        return null;
    }

    private bool CheckCorrectFormatting(string[] lines)
    {
        if (lines.Length == 2)
        {
            int[] spaces = { 0, 0 };

            for (int i = 0; i < 2; i++)
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

            return spaces[0] < spaces[1];
        }

        return false;
    }

    private string CheckWithOpenLine(string line)
    {
        string expectedLine = "withopen(\"pedidodesocorro.txt\",\"w\")aspedido:";
        string newLine = line.Replace("\'", "\"").Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace(" ", "").ToLower();
        string[] items = { "with", "open", "pedido", "de", "socorro", "txt", ",", "w", ")", "as", "pedido" };
        string[] list = line.Split(new char[] { ' ', '(', '\t', '\r', '\"', '\'', ':', '.' }, StringSplitOptions.RemoveEmptyEntries);

        if (list.Length == 11 && expectedLine == newLine)
        {
            fileObjects[0] = list[10];

            for (int i = 0; i < 11; i++)
            {
                if (i > 1 && i < 6 || i == 7 || i == 10)
                    list[i] = list[i].ToLower();

                if (items[i] != list[i])
                    return "";
            }

            return expectedLine;
        }

        return "";
    }

    private string CheckFunctionLine(string line)
    {
        string expectedLine = "pedido.write(\"socorro!\")";
        string newLine = line.Replace("\'", "\"").Replace("\n", "").Replace("\t", "").Replace("\r", "").Replace(" ", "").ToLower();
        string[] list = line.Split(new char[] { ' ', '.', '\t', '\r', '\"', '\'', '(', ')', '!' }, StringSplitOptions.RemoveEmptyEntries);
        string[] items = { "pedido", "write", "socorro" };

        if (list.Length == 3 && expectedLine == newLine)
        {
            fileObjects[1] = list[0];

            for (int i = 0; i < 3; i++)
            {
                if (i != 1)
                    list[i] = list[i].ToLower();

                if (items[i] != list[i])
                    return "";
            }

            return expectedLine;
        }

        return "";
    }

    protected override string PrintMessage()
    {
        return "Mensagem enviada!";
    }

    protected override string PrintErrorMessage()
    {
        return "Mensagem não enviada!\n\n" +
               "with open(\"nome do arquivo.extensao\", \"operacao\") as objeto:\n" +
               "\tobjeto.funcao(\"mensagem\")";
    }

    protected override string GetExpectedText()
    {
        return "withopen(\"pedidodesocorro.txt\",\"w\")aspedido:pedido.write(\"socorro!\")";
    }
}
