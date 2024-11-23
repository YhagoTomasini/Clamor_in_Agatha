using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpUp : MonoBehaviour
{
    public TextMeshProUGUI textoJump;
    public bool objTriggado;
    public bool podePular; 

    public GameObject character;
    public GameObject posiPulo;

    //public GameObject pulos;
    public GameObject triggerObjPulo;
    public bool objPulo = true;

    public Transform posiFilho;

    void Start()
    {
        character = GameObject.Find("Agatha");
        triggerObjPulo = GameObject.Find("triggerObjPulo");

        //pulos = GameObject.Find("pulos");

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
                if (podePular == true)
                {
                    StartCoroutine(teleportAction());
                    character.GetComponent<CharacterActs>().FuncPulo();
                }
            }
        }
    }

    IEnumerator teleportAction()
    {
        if (objTriggado && posiFilho != null)
        {
            yield return new WaitForSeconds(0.2f);
            podePular = false;
            if (objTriggado == true)
            {
                character.GetComponent<Transform>().position = posiFilho.GetComponent<Transform>().position;
            }

            yield return new WaitForSeconds(0.2f);
            podePular = true;

            yield return new WaitForSeconds(0.1f);
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
            if (podePular == true && other.gameObject.CompareTag("AlcancePulo"))
            {
                objTriggado = true;

                Transform filho = transform.GetChild(0);
                if (filho != null)
                {
                    posiFilho = filho;
                }
            }

            if (podePular == true && other.gameObject.CompareTag("AlcancePulo"))
            {
                textoJump.enabled = true;
            }
        }
        /*else
        {
            if (podePular == true && other.gameObject.CompareTag("AlcancePulo"))
            {
                objTriggado = false;
            }
        }*/
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
        
        /*
        else
        {
            if (podePular == true && other.gameObject.CompareTag("AlcancePulo"))
            {
                objTriggado = false;
            }
        }*/
    }
}