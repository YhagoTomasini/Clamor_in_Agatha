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

    public void DestinoInimigo()
    {
        Debug.Log("pure");
        meuAgente.SetDestination(destinoAtual);
                
    }

    private void Update()
    {
        destinoAtual = destino.position;
    }

    public void MeshBake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
    }
}
