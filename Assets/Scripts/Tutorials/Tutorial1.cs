using UnityEngine;

public class Tutorial1 : TutorialEvent
{
    private static bool destroyObject = false;

    protected override void Awake()
    {
        base.Awake();

        if (destroyObject)
            Destroy(obj);
    }

    protected override void ResetVariables()
    {
        destroyObject = false;
    }

    protected override string[] GetMessages()
    {
        string[] messages = new string[4];
        destroyObject = true;

        messages[0] = "Use Enter para interagir com o cenário e caixas de texto.";
        messages[1] = "Utilize as setas do teclado ou WASD para mover o personagem, e segure Shift para correr.";
        messages[2] = "Ao digitar um código, pressione Enter uma vez para saltar uma linha e duas vezes rapidamente para finalizar a digitação.";
        messages[3] = "Por fim, resolva desafios de Python para avançar no jogo!";

        return messages;
    }
}
