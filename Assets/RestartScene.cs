using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para trabalhar com o SceneManager

public class SceneReloader : MonoBehaviour
{
    // Função que reinicia a cena atual
    public void RestartScene()
    {
        // Obtém o nome da cena ativa e recarrega
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
