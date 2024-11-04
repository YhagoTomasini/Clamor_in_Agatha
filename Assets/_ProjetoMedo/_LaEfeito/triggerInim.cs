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
            StartCoroutine(DelayInim());
        }
    }
    IEnumerator DelayInim()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("NavMesh").GetComponent<NavMeshTest>().DestinoInimigo();
        yield return null;
    }

}
