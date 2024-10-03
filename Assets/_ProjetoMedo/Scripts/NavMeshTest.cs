using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{

    public NavMeshAgent meuAgente;
    public Transform destino;
    public Vector3 destinoAtual;

    public bool andando = false;
    public GameObject luzInim;

    private void Start()
    {

        luzInim = GameObject.Find("LuzInim");
        luzInim.SetActive(false);

        //StartCoroutine(AndaleAndale());
    }

    IEnumerator AndaleAndale()
    {
        while (true)
        {
            DestinoInimigo();

            yield return new WaitForSeconds(4f);
        }
    }
    public void DestinoInimigo()
    {
        meuAgente.SetDestination(destinoAtual);

        andando = true;
        StartCoroutine(AtivarPassos());
    }

    private void Update()
    {
        destinoAtual = destino.position;

        if(meuAgente.GetComponent<Transform>().position == destinoAtual)
        {
            andando = false;
            luzInim.SetActive(false);
        }
    }

    IEnumerator AtivarPassos()
    {
        luzInim.SetActive(true);

        while (andando)
        {
            GameObject.Find("Inimigo").GetComponent<ondaCoisa>().Andando();
            //Debug.Log("Fernando");

            yield return new WaitForSeconds(4f);
        }
    }
}