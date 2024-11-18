using UnityEngine;

public class Pause : MonoBehaviour

{
    //public GameObject pauseMenu;

    public GameObject meujogador;
    public GameObject canvaPause;
    private bool isPaused = false;

    private void Start()
    {
        canvaPause.SetActive(false);
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            GameObject.Find("AudioMusicManager").GetComponent<AudioSourceMusic>().TemaJogo();

            Time.timeScale = 1f;
            isPaused = false;
            meujogador.GetComponent<StarterAssets.FirstPersonController>().enabled = true;
            canvaPause.SetActive(false);


            //pauseMenu.SetActive(false);

            GameObject.Find("MainCamera").GetComponent<ondaSom>().enabled = true;
            Debug.Log("CACETE");

        }
        else
        {
            GameObject.Find("AudioMusicManager").GetComponent<AudioSourceMusic>().TemaMenu();

            Time.timeScale = 0f;
            isPaused = true;
            meujogador.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
            canvaPause.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            //pauseMenu.SetActive(true);  // Exibe o menu de pausa

            GameObject.Find("MainCamera").GetComponent<ondaSom>().enabled = false;
            Debug.Log("CACETE");

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }
}