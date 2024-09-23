using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutCaixa : MonoBehaviour
{
    public TextMeshProUGUI textoCut;
    private bool objTriggado;

    void Start()
    {
        if (textoCut == null)
        {
            GameObject cutTextObj = GameObject.Find("CutText");
            if (cutTextObj != null)
            {
                textoCut = cutTextObj.GetComponent<TextMeshProUGUI>();
            }
        }

        if (textoCut != null)
        {
            textoCut.enabled = false;
        }
        objTriggado = false;
    }

    void Update()
    {
        if (objTriggado && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);

            textoCut.enabled = false;

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textoCut.enabled = true;
            objTriggado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textoCut.enabled = false;
            objTriggado = false;
        }
    }
}