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

    private NavMeshSurface navMeshSurface;

    public bool andando = false;


    public void DestinoInimigo()
    {
        //Debug.Log("pure");
        meuAgente.SetDestination(destinoAtual);

        andando = true;
        //GameObject.Find("LuzInim").SetActive(true);
        StartCoroutine(AtivarPassos());
    }

    private void Update()
    {
        destinoAtual = destino.position;

        if(meuAgente.GetComponent<Transform>().position == destinoAtual)
        {
            andando = false;
            //GameObject.Find("LuzInim").SetActive(false);

        }
    }

    public void MeshBake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
    }

    IEnumerator AtivarPassos()
    {
        while (andando)
        {
            GameObject.Find("Inimigo").GetComponent<ondaCoisa>().Andando();
            Debug.Log("Fernando");

            yield return new WaitForSeconds(4f);
        }
    }
}