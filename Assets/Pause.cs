using UnityEngine;

public class PauseGame : MonoBehaviour

{
    public GameObject pauseMenu;
    // Variável para verificar se o jogo está pausado
    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false); // Esconde o menu de pausa
            isPaused = false;
            GameObject.Find("MainCamera").GetComponent<ondaSom>().enabled = true;
            Debug.Log("CACETE");
            
        }
        else
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);  // Exibe o menu de pausa
            isPaused = true;
            GameObject.Find("MainCamera").GetComponent<ondaSom>().enabled = false;
            Debug.Log("CACETE");

        }
    }

    void Update()
    {
        // Verifica se a tecla "P" foi pressionada
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }
}