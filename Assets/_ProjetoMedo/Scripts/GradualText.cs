using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GradualTMPTextOnCanvas : MonoBehaviour
{
    public TMP_Text tmpText; // Refer�ncia ao componente TMP_Text
    private string fullText  = "You went to sleep last night, life’s been hard lately, you never find food and it’s always dangerous outside, you had a nightmare and wake up afraid, the life of a blind person is hard.\n\nYou sense a wall near you, the ground. When you say something... You see! For a brief moment but you see! High walls and a gigantic world, it's a dream? Maybe somebody or something brought you here... To this strange world.";
    public float typingSpeed = 0.05f; // Velocidade entre cada caractere

   
    private void OnEnable()
    {
        // Inicia o efeito de texto quando o Canvas for ativado
        StartCoroutine(DisplayTextGradually());
    }

    private void Update()
    {
      
    }

    IEnumerator DisplayTextGradually()
    {
        tmpText.text = ""; // Limpa o texto inicialmente

        foreach (char letter in fullText.ToCharArray())
        {
            tmpText.text += letter; // Adiciona uma letra ao texto
            yield return new WaitForSeconds(typingSpeed); // Aguarda a velocidade configurada
        }
      
    }
}
