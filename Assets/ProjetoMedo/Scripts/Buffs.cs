using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    public GameObject orbsBuff;
    public GameObject barraProgressao;
    public float valorProgressao;

    // Start is called before the first frame update
    void Start()
    {
        valorProgressao = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Buffs"))
        {
            //Aumentar barra de progressao. Por anima��o bm estilo flowlab.
            valorProgressao += 1;

            Destroy(gameObject);
        }

        if (valorProgressao >= 2)
        {
            //Aumentar barra de progressao.
            //Ativar buff de quebrar.

            //Se colidir com objeto invisivel de caixa;
                //ativar objeto de aviso de ativacao
                //Se apertar botao
                    //funcao da caixa               
        }
        if (valorProgressao >= 5)
        {
            //Aumentar barra de progressao.
            //Ativar buff de pular.

            //Se colidir com objeto invisivel de altonivel;
                //ativar objeto de aviso de ativacao
                //Se apertar botao
                    //funcao de pulo  

        }
        if (valorProgressao >= 9)
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