using TMPro; // Biblioteca do TextMeshPro
using UnityEngine;
using UnityEngine.EventSystems; // Biblioteca necessária para eventos de UI

public class UnderlineTextOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Referência para o TextMeshProUGUI
    private TextMeshProUGUI textComponent;
    private AudioSource audioSource;

    void Start()
    {
        // Obtém o componente TextMeshProUGUI do objeto
        textComponent = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    // Evento disparado quando o ponteiro do mouse entra na área do texto
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Adiciona a tag de sublinhado ao texto
        textComponent.text = "<u>" + textComponent.text + "</u>";
        if (audioSource != null)
        {
            audioSource.Play();
        }

    }

    // Evento disparado quando o ponteiro do mouse sai da área do texto
    public void OnPointerExit(PointerEventData eventData)
    {
        // Remove a tag de sublinhado
        textComponent.text = textComponent.text.Replace("<u>", "").Replace("</u>", "");
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
