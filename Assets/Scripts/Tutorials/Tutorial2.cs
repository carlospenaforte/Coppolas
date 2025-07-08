using UnityEngine;

public class Tutorial2 : TutorialEvent
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
        string[] messages = new string[1];

        messages[0] = "Pressione o Espaço ou o botão esquerdo do mouse para atacar os inimigos!";
        destroyObject = true;

        return messages;
    }
}
