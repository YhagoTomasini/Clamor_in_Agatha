using UnityEngine;
using TMPro;
using System.Collections;

public class GradualTMPTextOnCanvas : MonoBehaviour
{
    public TMP_Text tmpText; // Referência ao componente TMP_Text
    public string fullText = "You went to sleep last night, you only remeber going to sleep after a very long day, you were tired and really exausted, however your day was normal, nothing different from the normal days... After waking up, you feel... Dizzy, like the world is spining round and round and you can't find reason, after a some time you settle and  try to open your eyes.   Nothing.Absolute   Nothing.  You can't see.  You remember that you are blind.  Well you sense a wall near you, the ground, when you think about saying hello, you see the world!   For a brief moment but you see!   High walls and a gigantic world, you were dreaming? Maybe somebody did something to you...Brought you to this stange world   All you can sense is some white circles that you can touch, It kind of has a good smell, maybe it can help... ";
    public float typingSpeed = 0.05f; // Velocidade entre cada caractere

    private void OnEnable()
    {
        // Inicia o efeito de texto quando o Canvas for ativado
        StartCoroutine(DisplayTextGradually());
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
