using UnityEngine;
using TMPro;

[System.Serializable]
public class ConteudoPython
{
    public string basico;
    public string condicionais;
    public string lacos;
    public string listas;
    public string tuplas;
    public string funcoes;
}

public class TabletContentManager : MonoBehaviour
{
    public TextMeshProUGUI contentText;
    private ConteudoPython conteudo;
    public GameObject buttonsPanel;
    public GameObject botaoVoltar;

    void Start()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Tablet/conteudos");
        if (jsonFile != null)
        {
            conteudo = JsonUtility.FromJson<ConteudoPython>(jsonFile.text);
            Debug.Log("JSON carregado com sucesso!");
        }
        else
        {
            Debug.LogError("Arquivo JSON 'conteudos.json' não encontrado em Resources!");
        }

        contentText.text = ""; // começa vazio
    }

    public void MostrarConteudo(string topico)
    {
        buttonsPanel.SetActive(false); // oculta os botões
        botaoVoltar.SetActive(true); // mostra botão "voltar"

        switch (topico)
        {
            case "basico":
                contentText.text = conteudo.basico;
                break;
            case "condicionais":
                contentText.text = conteudo.condicionais;
                break;
            case "lacos":
                contentText.text = conteudo.lacos;
                break;
            case "listas":
                contentText.text = conteudo.listas;
                break;
            case "tuplas":
                contentText.text = conteudo.tuplas;
                break;
            case "funcoes":
                contentText.text = conteudo.funcoes;
                break;
            default:
                contentText.text = "Conteúdo não encontrado.";
                break;
        }
    }
    
    public void Voltar()
    {
        contentText.text = "";               // limpa o texto
        buttonsPanel.SetActive(true);        // mostra os botões novamente
        botaoVoltar.SetActive(false);        // esconde o botão "Voltar"
    }
    

}
