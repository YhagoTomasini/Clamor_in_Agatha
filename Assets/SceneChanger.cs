using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para trabalhar com o SceneManager

public class SceneChanger : MonoBehaviour
{
    // Método para trocar de cena, onde o nome da cena é passado como argumento
    public void ChangeScene(string oJogo)
    {
        SceneManager.LoadScene(oJogo); // Troca para a cena especificada
        Debug.Log("Deus");
    }
}
