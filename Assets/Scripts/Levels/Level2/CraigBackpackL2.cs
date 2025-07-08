public class CraigBackpackL2 : TextEvent
{
    protected override string GetDialogueText()
    {
        return "Crie um dicionário chamado mochila contendo três chaves, " +
               "todas no formato de string: Coldre, Cartucho e Cinto, associando " +
               "a cada uma delas um valor também em string, os quais são Revólver, " +
               "Balas e Granadas, respectivamente. Utilize a sintaxe correta de " +
               "dicionário em Python, como no exemplo: dicionario = " +
               "{ chave1: valor1, chave2: valor2, ..., chaveN: valorN }.";
    }
}
