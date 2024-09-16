using UnityEngine;
using UnityEngine.UI;

public class ShowCredits : MonoBehaviour
{
    // Referência para o Canvas dos créditos e o Canvas principal
    public GameObject creditsCanvas;
    public GameObject mainCanvas;

    // Método para abrir os créditos
    public void OpenCredits()
    {
        // Desativa o Canvas principal
        mainCanvas.SetActive(false);

        // Ativa o Canvas dos créditos
        creditsCanvas.SetActive(true);
    }

    // Método para voltar ao menu principal (opcional)
    public void BackToMainMenu()
    {
        // Ativa o Canvas principal
        mainCanvas.SetActive(true);

        // Desativa o Canvas dos créditos
        creditsCanvas.SetActive(false);
    }
}
