using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmesTest : MonoBehaviour
{

    public NavMeshAgent meuAgente;

    public Transform destino;

    private void Start()
    {
        meuAgente.SetDestination(destino.position);
    }
}
