using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{

    public NavMeshAgent meuAgente;
    public Transform destino;

    public void DestinoInimigo()
    {
        Debug.Log("pure");

        meuAgente.SetDestination(destino.position);
    }
}
