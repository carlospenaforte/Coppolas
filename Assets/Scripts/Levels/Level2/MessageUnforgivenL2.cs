public class MessageUnforgivenL2 : TextEvent
{
    protected override string GetDialogueText()
    {
        return "Utilize a estrutura \"with open\" para abrir (ou criar) " +
               "um arquivo de texto chamado Pedido de Socorro no " +
               "modo de ESCRITA. Dentro do bloco \"with\", crie um objeto " +
               "com o nome pedido e utilize-o para escrever no arquivo a " +
               "linha \"SOCORRO!\".";
    }
}
