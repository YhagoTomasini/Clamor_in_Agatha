using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Método chamado ao apertar o botão de "Quit"
    public void Quit()
    {
        // Se estiver rodando fora do editor, o jogo será fechado
        Application.Quit();

        // Para feedback durante o desenvolvimento no editor do Unity
#if UNITY_EDITOR
        Debug.Log("O jogo foi fechado (simulado no editor)");
#endif
    }
}
