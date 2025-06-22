public class AntonDetonatorL1 : TextEvent
{
    protected override string GetDialogueText()
    {
        if (BombMakerL1.GetBombMaked())
            return "Aproxime - se da porta e digite o índice da lista que corresponde ao Detonador.\n\n" + BombMakerL1.GetMyBomb();

        return "Crie a bomba e exploda a porta!";
    }
}
