using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuERestart : MonoBehaviour
{
    // public bool clicarMouse = false;
    // private void Update()
    // {
    //     if (clicarMouse && Input.GetKeyDown(KeyCode.Mouse0))
    //     {
    //         CenaUi();
    //     }

    //     if (clicarMouse && Input.GetKeyDown(KeyCode.Mouse1))
    //     {
    //         CenaJogo();
    //     }
    // }

    public void CenaUi()
    {
        GameObject.Find("PauseManager").GetComponent<Pause>().TogglePause();
        

        Debug.Log("Carregando cena UiGame");
        SceneManager.LoadScene("UiGame");
    }
    public void CenaJogo()
    {
        GameObject.Find("PauseManager").GetComponent<Pause>().TogglePause();
        

        Debug.Log("Carregando cena oJogo");
        SceneManager.LoadScene("oJogo");
    }

   
}