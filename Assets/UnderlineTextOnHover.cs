using TMPro; // Biblioteca do TextMeshPro
using UnityEngine;
using UnityEngine.EventSystems; // Biblioteca necessária para eventos de UI

public class UnderlineTextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Referência para o TextMeshProUGUI
    private TextMeshProUGUI textComponent;

    void Start()
    {
        // Obtém o componente TextMeshProUGUI do objeto
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    // Evento disparado quando o ponteiro do mouse entra na área do texto
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Adiciona a tag de sublinhado ao texto
        textComponent.text = "<u>" + textComponent.text + "</u>";
    }

    // Evento disparado quando o ponteiro do mouse sai da área do texto
    public void OnPointerExit(PointerEventData eventData)
    {
        // Remove a tag de sublinhado
        textComponent.text = textComponent.text.Replace("<u>", "").Replace("</u>", "");
    }
}
