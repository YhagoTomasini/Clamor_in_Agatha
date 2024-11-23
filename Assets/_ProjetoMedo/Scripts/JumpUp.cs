using System.Collections;
using TMPro;
using UnityEngine;

public class JumpUp : MonoBehaviour
{
    public TextMeshProUGUI textoJump;
    private bool objTriggado;
    public bool podePular;

    public GameObject character;
    public Transform posiFilho;

    private static JumpUp activeJumpUp; // Controle único para evitar conflitos

    void Start()
    {
        character = GameObject.Find("Agatha");
        podePular = false;

        if (textoJump == null)
        {
            GameObject jumpTextObj = GameObject.Find("JumpText");

            if (jumpTextObj != null)
            {
                textoJump = jumpTextObj.GetComponent<TextMeshProUGUI>();
            }
        }

        if (textoJump != null)
        {
            textoJump.enabled = false;
        }

        objTriggado = false;
    }

    void Update()
    {
        if (objTriggado && Input.GetKeyDown(KeyCode.Space) || objTriggado && Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (podePular && activeJumpUp == this) // Garante que apenas a instância ativa realiza o teleporte
            {
                StartCoroutine(TeleportAction());
                character.GetComponent<CharacterActs>().FuncPulo();
            }
        }
    }

    IEnumerator TeleportAction()
    {
        if (posiFilho != null)
        {
            podePular = false; // Bloqueia outras ações
            yield return new WaitForSeconds(0.2f);

            character.transform.position = posiFilho.position;

            yield return new WaitForSeconds(0.2f);
            podePular = true; // Libera novamente após o teleporte
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AlcancePulo"))
        {
            objTriggado = true;

            if (activeJumpUp == null) // Define o controle ativo
            {
                activeJumpUp = this;
            }

            posiFilho = transform.GetChild(0); // Atribui o filho para teleporte
            if (textoJump != null)
            {
                textoJump.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AlcancePulo"))
        {
            objTriggado = false;

            if (activeJumpUp == this) // Libera o controle ativo
            {
                activeJumpUp = null;
            }

            posiFilho = null;

            if (textoJump != null)
            {
                textoJump.enabled = false;
            }
        }
    }
}
