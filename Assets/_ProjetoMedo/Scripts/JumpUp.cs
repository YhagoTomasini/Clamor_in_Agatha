using StarterAssets;
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

    public bool objPulo = true;

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
        if (objPulo)
        {
            if (objTriggado && Input.GetKeyDown(KeyCode.Space) || objTriggado && Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (podePular)
                {
                    StartCoroutine(TeleportAction());
                    character.GetComponent<CharacterActs>().FuncPulo();
                }
            }
        }
    }

    IEnumerator TeleportAction()
    {
        if (posiFilho != null)
        {
            GameObject.Find("Agatha").GetComponent<FirstPersonController>().BloqueioMove();
            podePular = false;
            yield return new WaitForSeconds(0.2f);

            character.transform.position = posiFilho.position;
            textoJump.enabled = false;

            yield return new WaitForSeconds(0.2f);
            GameObject.Find("Agatha").GetComponent<FirstPersonController>().BloqueioMove();
            podePular = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerObjPulo"))
        {
            objPulo = false;
        }

        if (objPulo)
        {
            if (podePular && other.gameObject.CompareTag("AlcancePulo"))
            {
                objTriggado = true;

                Transform filho = transform.GetChild(0);
                if (filho != null)
                {
                    posiFilho = filho;
                }
            }

            if (podePular && other.gameObject.CompareTag("AlcancePulo"))
            {
                textoJump.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerObjPulo"))
        {
            objPulo = true;
        }

        if (posiFilho != null)
        {
            posiFilho = null;
        }

        if (podePular == true && other.gameObject.CompareTag("AlcancePulo"))
        {
            objTriggado = false;
        }

        if (podePular == true && other.gameObject.CompareTag("AlcancePulo"))
        {
            textoJump.enabled = false;
        }
    }
}
