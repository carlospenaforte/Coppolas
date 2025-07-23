    using UnityEngine;

public class TabletController : MonoBehaviour
{
    public TabletContentManager tabletContentManager;

    public GameObject buttonsPanel;

    public RectTransform tabletUI;
    private bool isOpen = false;

    // Tamanhos para minimizar e expandir
    private Vector2 minimizedSize = new Vector2(40, 50);
    private Vector2 expandedSize = new Vector2(500, 300);

    private Vector2 minimizedPos = new Vector2(430, -120); // canto inferior direito
    private Vector2 expandedPos = Vector2.zero; // centro da tela

    void Start()
    {
        MinimizeTablet();
        buttonsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isOpen)
                MinimizeTablet();
            else
                ExpandTablet();
        }
    }

    void ExpandTablet()
    {
        isOpen = true;
        tabletUI.sizeDelta = expandedSize;
        tabletUI.anchoredPosition = expandedPos;

        buttonsPanel.SetActive(true);
    }

    void MinimizeTablet()
    {
        isOpen = false;
        tabletUI.sizeDelta = minimizedSize;
        tabletUI.anchoredPosition = minimizedPos;

        buttonsPanel.SetActive(false);
        tabletContentManager.contentText.text = ""; // limpa o conteúdo
        tabletContentManager.botaoVoltar.SetActive(false);
    }

}
