using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Buffs : MonoBehaviour
{
    public GameObject[] todosBuffs;
    public GameObject[] caixas;

    public GameObject barraCanva;
    public RectTransform rectBarra;
    public float valorbarraNor;
    private float valorBarraAtual;
    private float valorBarraMax = 10;

    //public Renderer buffRender;

    // Start is called before the first frame update
    void Start()
    {
        caixas = GameObject.FindGameObjectsWithTag("Caixas");
        todosBuffs = GameObject.FindGameObjectsWithTag("Buffs");

        foreach (GameObject buffs in todosBuffs)
        {
            MeshRenderer buffRender = buffs.GetComponent<MeshRenderer>();

            buffRender.material.color = Color.red;

            valorBarraAtual = 0;
            rectBarra = barraCanva.GetComponent<RectTransform>();

            progredirBarra();
        }
    }

    void progredirBarra()
    {
        valorbarraNor = valorBarraAtual / valorBarraMax;
        rectBarra.localScale = new Vector3(valorbarraNor, 1, 1);
    }

    //void mudarCor()
    //{
    //    foreach (GameObject buffs in todosBuffs)
    //    {
    //        MeshRenderer buffRender = buffs.GetComponent<MeshRenderer>();

    //        buffRender.material.color = Color.green;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buffs"))
        {
            //Debug.Log("arooz");
            valorBarraAtual += 1;

            progredirBarra();
            Destroy(other.gameObject);
        }

        
        if (valorBarraAtual >= 1 && caixas.Length > 0)
        {
            mudarCor();
        }
        if (valorBarraAtual >= 2 && caixas.Length > 0)
            {
                //Debug.Log("feijao1");
                foreach (GameObject caixa in caixas)
                {
                    CutCaixa cutCaixas = caixa.GetComponent<CutCaixa>();

                    if (cutCaixas != null)
                    {
                        //Debug.Log("feijao2");
                        cutCaixas.podeQuebrar = true;
                    }
                }

                //ativar objeto de aviso de ativacao
        }
        if (valorBarraAtual >= 5)
        {
            //Aumentar barra de progressao.
            //Ativar buff de pular.

            //Se colidir com objeto invisivel de altonivel;
                //ativar objeto de aviso de ativacao
                //Se apertar botao
                    //funcao de pulo  

        }
        if (valorBarraAtual >= 9)
        {
            //Aumentar barra de progressao.
            //Ativar buff de shrek.

            //Se colidir com objeto invisivel de shirink;
                //ativar objeto de aviso de ativacao
                //Se apertar botao
                    //funcao de shrink  

        }
    }
}