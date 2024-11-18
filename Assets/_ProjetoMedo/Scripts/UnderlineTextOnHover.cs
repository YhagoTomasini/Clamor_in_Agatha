using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnderlineTextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Adiciona a tag de sublinhado ao texto
        textComponent.text = "<u>" + textComponent.text + "</u>";
        
        GameObject.Find("AudioEffectsManager").GetComponent<AudioSourceGeral>().SomBotao();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Remove a tag de sublinhado
        textComponent.text = textComponent.text.Replace("<u>", "").Replace("</u>", "");
    }
}
