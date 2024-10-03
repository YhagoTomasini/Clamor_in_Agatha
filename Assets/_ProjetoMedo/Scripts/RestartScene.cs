using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para trabalhar com o SceneManager

public class SceneReloader : MonoBehaviour
{
  
    public void RestartScene()
    {
     
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }
}
