using UnityEngine;
using UnityEngine.UI; // Biblioteca para UI

public class ScreenModeToggle : MonoBehaviour
{
    // Referência para o Toggle no Inspector
    public Toggle screenModeToggle;

    void Start()
    {
        // Adiciona um listener para verificar quando o Toggle é alterado
        screenModeToggle.onValueChanged.AddListener(ToggleScreenMode);

        // Define o estado inicial do Toggle baseado no estado atual da tela
        screenModeToggle.isOn = Screen.fullScreen;
    }

    // Método chamado quando o estado do Toggle muda
    public void ToggleScreenMode(bool isFullScreen)
    {
        if (isFullScreen)
        {
            // Se o Toggle estiver ligado, ativa o modo tela cheia maximizada
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
            Screen.fullScreen = true;
            Debug.Log("Fstrue");
        }
        else
        {
            // Se o Toggle estiver desligado, ativa o modo janela
            Screen.fullScreen = false;
            Debug.Log("Fsfalse");
        }
    }
}
