using UnityEngine;
using UnityEngine.UI;

public class ShowCredits : MonoBehaviour
{
    // Referência para o Canvas dos créditos e o Canvas principal
    public GameObject creditsCanvas;
    public GameObject mainCanvas;
    public GameObject settingsCanvas;
    public GameObject controlsCanvas;
    public GameObject playCanvas;

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
    public void BackToMainMenu2()
    {
        // Ativa o Canvas principal
        mainCanvas.SetActive(true);

        // Desativa o Canvas dos créditos
        settingsCanvas.SetActive(false);
    }
    public void OpenSettings()
    {
        // Desativa o Canvas principal
        mainCanvas.SetActive(false);

        // Ativa o Canvas dos créditos
        settingsCanvas.SetActive(true);
    }
    public void OpenControls()
    {
        // Desativa o Canvas principal
        mainCanvas.SetActive(false);

        // Ativa o Canvas dos créditos
        controlsCanvas.SetActive(true);
    }
    public void BackToMainMenu3()
    {
        // Ativa o Canvas principal
        mainCanvas.SetActive(true);

        // Desativa o Canvas dos créditos
        controlsCanvas.SetActive(false);
    }
     public void OpenPlay()
    {
        // Desativa o Canvas principal
        mainCanvas.SetActive(false);

        // Ativa o Canvas dos créditos
        playCanvas.SetActive(true);
    }
     public void BackToMainMenu4()
    {
        // Ativa o Canvas principal
        mainCanvas.SetActive(true);

        // Desativa o Canvas dos créditos
        playCanvas.SetActive(false);
    }
}
