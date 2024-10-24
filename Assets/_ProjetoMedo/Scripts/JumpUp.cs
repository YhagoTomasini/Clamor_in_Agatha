using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpUp : MonoBehaviour
{
    public TextMeshProUGUI textoJump;
    private bool objTriggado;
    public bool podePular;
    public float jumpForce = 10f;

    public GameObject character;
    public GameObject posiPulo;

    public GameObject playerCapsuleToTeleport;

    //public Collider coAtual;
    //public Collider coVisao;

    void Start()
    {
        playerCapsuleToTeleport = GameObject.Find("PlayerCapsule");
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
            if (podePular==true)
            {
                StartCoroutine(teleportAction());
            }
        }
    }


    IEnumerator teleportAction()
    {
        playerCapsuleToTeleport.SetActive(false);
        //coAtual = null;
        //coVisao = null;

        yield return new  WaitForSeconds(0.5f);

        //coAtual = coVisao;
        character.GetComponent<Transform>().position = posiPulo.GetComponent<Transform>().position;
        yield return new  WaitForSeconds(0.5f);

        playerCapsuleToTeleport.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (podePular==true && other.gameObject.CompareTag("AlcancePulo"))
        {

            textoJump.enabled = true;
            objTriggado = true;
            //if (coAtual != other)
            {
                //coVisao = other;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (podePular==true && other.gameObject.CompareTag("AlcancePulo"))
        {
            textoJump.enabled = false;
            objTriggado = false;
            //coVisao = null;
        }
    }
}