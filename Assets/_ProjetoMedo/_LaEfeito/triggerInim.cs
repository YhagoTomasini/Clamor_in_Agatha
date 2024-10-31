using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerInim : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dano"))
        {
            Debug.Log("colidiu c o dano");
            GameObject.Find("NavMesh").GetComponent<NavMeshTest>().DestinoInimigo();
        }
    }
}
