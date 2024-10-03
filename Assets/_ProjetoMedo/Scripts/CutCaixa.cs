using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutCaixa : MonoBehaviour
{
    public TextMeshProUGUI textoCut;
    private bool objTriggado;

    public bool podeQuebrar;

    void Start()
    {
        podeQuebrar = false;
        
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
        if (objTriggado && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (podeQuebrar==true)
            {
                cortaCaixa();
            }
        }
    }

    void cortaCaixa()
    {
        Destroy(gameObject);

        textoCut.enabled = false;

        GameObject.Find("NavMesh").GetComponent<NavMeshTest>().MeshBake();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (podeQuebrar==true && other.gameObject.CompareTag("Player"))
        {
            textoCut.enabled = true;
            objTriggado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (podeQuebrar==true && other.gameObject.CompareTag("Player"))
        {
            textoCut.enabled = false;
            objTriggado = false;
        }
    }
}