using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPulo : MonoBehaviour
{
    public GameObject pulos;

    private void OnTriggerStay(Collider other)
    { 
        if (other.gameObject.CompareTag("TriggerObjPulo"))
        {
            Debug.Log("enrtrou no block");
            if (pulos != null)
            {
                foreach (Transform child in pulos.transform)
                {
                    JumpUp jumpUp = child.GetComponent<JumpUp>();

                    if (jumpUp != null)
                    {
                        jumpUp.podePular = false;
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("saiu no block");
        if (other.gameObject.CompareTag("TriggerObjPulo"))
        {
            if (pulos != null)
            {
                foreach (Transform child in pulos.transform)
                {
                    JumpUp jumpUp = child.GetComponent<JumpUp>();

                    if (jumpUp != null)
                    {
                        jumpUp.podePular = true;
                    }
                }
            }
        }
    }
}
