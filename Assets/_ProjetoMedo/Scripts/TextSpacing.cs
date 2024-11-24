using UnityEngine;
using TMPro;

public class TMPTextSpacing : MonoBehaviour
{
    public TMP_Text tmpText; // Referencia ao componente TMP_Text
    public float wordSpacing = 20f; // Espacamento entre caracteres
    public float lineSpacing = 20f;
    public float paragraphSpacing = 20f;

    void OnEnable()
    {
        // Define o espaçamento entre caracteres
        tmpText.wordSpacing = wordSpacing;
        tmpText.lineSpacing = lineSpacing;
        tmpText.paragraphSpacing = paragraphSpacing;
    }
}
