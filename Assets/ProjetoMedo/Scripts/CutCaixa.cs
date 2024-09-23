using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutCaixa : MonoBehaviour
{
    public GameObject textoCut;
    private bool objTriggado;

    void Start()
    {
        textoCut.SetActive(false);
        objTriggado = false;
    }

    void Update()
    {
        if (objTriggado && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textoCut.SetActive(true);
            objTriggado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textoCut.SetActive(false);
            objTriggado = false;
        }
    }
}