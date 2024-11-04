using System;
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

    public GameObject pulos;
    public GameObject triggerObjPulo;
    public bool objPulo = true;

    void Start()
    {
        character = GameObject.Find("Agatha");
        triggerObjPulo = GameObject.Find("triggerObjPulo");

        pulos = GameObject.Find("pulos");

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
                character.GetComponent<CharacterActs>().FuncPulo();
            }
        }
    }

    IEnumerator teleportAction()
    {
        yield return new  WaitForSeconds(0.5f);
        character.GetComponent<Transform>().position = posiPulo.GetComponent<Transform>().position;
        yield return new WaitForSeconds(0.5f);
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerObjPulo"))
        {
            objPulo = false;
        }

        if (objPulo)
        {
            if (other.gameObject.CompareTag("AlcancePulo") == true)
            {
                objTriggado = true;
            }

            if (podePular == true && other.gameObject.CompareTag("AlcancePulo"))
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

        if (objPulo)
        {
            if (other.gameObject.CompareTag("AlcancePulo") == true)
            {
                objTriggado = false;
            }

            if (podePular == true && other.gameObject.CompareTag("AlcancePulo"))
            {
                textoJump.enabled = false;
            }
        }
    }
}