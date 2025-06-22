public class CraigLampL2 : TextEvent
{
    protected override string GetDialogueText()
    {
        return "Crie uma função chamada acender_luzes, em Python, " +
               "que recebe uma lista de valores booleanos chamada luzes_ligadas. " +
               "Dentro da função, utilize um loop no formato \"for i in range(len(lista))\" " +
               "para percorrer os índices da lista. Em cada posição, atribua o valor \"verdadeiro\". " +
               "Não é necessário usar \"return\", já que listas são alteradas por referência.";
    }
}
