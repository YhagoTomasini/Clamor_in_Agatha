using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JumpUp : MonoBehaviour
{
    public TextMeshProUGUI textoJump;
    private bool objTriggado;
    public bool podePular;
    public float jumpForce = 10f;

    public Transform Character;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        podePular = false;
        
        if (textoJump == null)
        {
            GameObject jumpTextObj = GameObject.Find("JumpText");

            if (jumpTextObj != null)
            {
                textoJump = jumpTextObj.GetComponent<TextMeshProUGUI>();
            }
        }

        if (textoJump != null)
        {
            textoJump.enabled = false;
        }
        objTriggado = false;
    }

    void Update()
    {
        if (objTriggado && Input.GetKeyDown(KeyCode.Space) || objTriggado && Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (podePular==true)
            {
                pularPraCima();
            }
        }
    }

    public void pularPraCima()
    {
        textoJump.enabled = false;

        // Calcular a direção para o alvo
        Vector3 direction = Character.position - transform.position;
        direction.y = 0;

        // Calcular a velocidade inicial
        float distance = direction.magnitude;
        float angle = 45f;
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * Mathf.Deg2Rad * angle));

        // Aplicar a força inicial
        rb.velocity = velocity * direction.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (podePular==true && other.gameObject.CompareTag("AlcancePulo"))
        {
            textoJump.enabled = true;
            objTriggado = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (podePular==true && other.gameObject.CompareTag("AlcancePulo"))
        {
            textoJump.enabled = false;
            objTriggado = false;
        }
    }
}