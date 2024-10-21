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
                pularPraCima();
                
            }
        }
    }

    public void pularPraCima()
    {
        character.GetComponent<Transform>().position = posiPulo.GetComponent<Transform>().position;
        
        Debug.Log("trigodopulo");
    }


    IEnumerator teleportAction()
    {
        playerCapsuleToTeleport.SetActive(false);
        yield return new  WaitForSeconds(0.5f);
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (podePular==true && other.gameObject.CompareTag("AlcancePulo"))
        {
            textoJump.enabled = false;
            objTriggado = false;
        }
    }
}