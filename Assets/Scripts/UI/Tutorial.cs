using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;

    private string[] messages = {
        "Use as teclas WASD para se mover",
        "Aperte SHIFT para correr rapidão",
        "Aperte ENTER para interagir"
    };

    private int index = 0;

    void Start()
    {
        TutorialAparece();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // APERTAR IRÁ PARA PRÓXIMA MENSAGEM
        {
            NextMessage();
        }
    }

    // Classes

    void TutorialAparece()
    {
        tutorialText.text = messages[index]; 
    }

    void NextMessage()
    {
        index++; // incrementa index para pular a mensagem após clique

        if (index < messages.Length)
        {
            TutorialAparece();
        }
        else
        {
            tutorialText.gameObject.SetActive(false); //finaliza as mensagens 
        }
    }
}
