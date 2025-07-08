using UnityEngine;

public class AntonNPCL1 : TextEvent
{
    private static int[] coordinates = { 1, 1, 1 };
    private static string[] direction = new string[3];
    private string[][] matrix = new string[][]
    {
        new string[] { "direita", "esquerda" },
        new string[] { "cima", "baixo" },
        new string[] { "frente", "trás" }
    };

    protected override void Awake()
    {
        base.Awake();

        if (coordinates[1] == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i != 1)
                    coordinates[i] = UnityEngine.Random.Range(0, 2) == 1 ? 20 : -20;

                coordinates[i] *= UnityEngine.Random.Range(5, 50) * 10;
                direction[i] = coordinates[i] > 0 ? matrix[i][0] : matrix[i][1];
            }
        }
    }

    protected override void ResetVariables()
    {
        coordinates[1] = 1;
    }

    protected override string GetDialogueText()
    {
        return "Considere um sistema de coordenadas tridimensionais no espaço com as seguintes convenções:\n\n" +
               "Eixo x: valores positivos indicam movimento para a direita, valores negativos para a esquerda.\n" +
               "Eixo y: valores positivos indicam movimento para cima, valores negativos para baixo.\n" +
               "Eixo z: valores positivos indicam movimento para a frente, valores negativos para trás.\n\n" +
               "Você deve criar uma função em Python chamada mover_nave que não recebe parâmetros e retorna" +
               " uma tupla com os valores inteiros (x, y, z) escalados em metros, " +
               "representando o deslocamento da nave Stella Nova com base nas seguintes instruções de voo:\n\n" +
               $"\tMover {Mathf.Abs(coordinates[0] / 1000f)} km para a {direction[0]}\n" +
               $"\tMover {coordinates[1]} metros para {direction[1]}\n" +
               $"\tMover {Mathf.Abs(coordinates[2] / 1000f)} km para a {direction[2]}\n\n" +
               "Atenção: todos os valores devem ser convertidos para metros na resposta final.";
    }

    public static int GetCoordinate(int i)
    {
        return coordinates[i];
    }
}
