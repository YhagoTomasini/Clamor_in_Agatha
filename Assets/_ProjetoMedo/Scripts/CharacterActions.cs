using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class CharacterActs : MonoBehaviour
{
    public GameObject[] caixas;

    public GameObject barraCanva;
    public RectTransform rectBarra;
    public float valorbarraNor;
    public float valorBarraAtual;
    private float valorBarraMax = 10;

    public Image whiteBlur;

    public GameObject canvaMorte;
    public GameObject iconFaca;
    public GameObject iconPulo;
    public GameObject iconShrek;

    void Start()
    {
        //whiteBlur = GameObject.Find("WBlurTex");
        whiteBlur.gameObject.SetActive(false);

        canvaMorte = GameObject.Find("CanvasRestart");
        iconFaca = GameObject.Find("IconFaca");
        iconPulo = GameObject.Find("IconPulo");
        iconShrek = GameObject.Find("IconShrek");

        canvaMorte.SetActive(false);
        iconFaca.SetActive(false);
        iconPulo.SetActive(false); 
        iconShrek.SetActive(false);


        caixas = GameObject.FindGameObjectsWithTag("Caixas");
        
        valorBarraAtual = 0;
        rectBarra = barraCanva.GetComponent<RectTransform>();

        progredirBarra();

    }

    void progredirBarra()
    {
        valorbarraNor = valorBarraAtual / valorBarraMax;
        rectBarra.localScale = new Vector3(valorbarraNor, 1, 1);
    }

    IEnumerator EfeitoBuff(float duracaoFade)
    {
        whiteBlur.gameObject.SetActive(true);
        Color blurColor = whiteBlur.color;

        blurColor.a = 0.3f;
        whiteBlur.color = blurColor;

        float duracao = 0f;

        while (duracao < duracaoFade)
        {
            blurColor.a = Mathf.Lerp(0.3f, 0f, duracao / duracaoFade);
            whiteBlur.color = blurColor;
            duracao += Time.deltaTime;

            yield return null;
        }

        blurColor.a = 0f;
        whiteBlur.color = blurColor;
        whiteBlur.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        //FUNCAO MORTE
        if (other.CompareTag("Dano"))
        {
            AcabarJogo();
        }

        //FUNCAO BUFFS
        if (other.CompareTag("Buffs"))
        {
            valorBarraAtual += 1;

            progredirBarra();
            //Acessar componente de global volume e colocar gama para 2 e diminuir eponenciamentepara 1
            StartCoroutine (EfeitoBuff(0.5f));

            if (other != null)
            {
                Destroy(other.gameObject);
            }
        }


        if (valorBarraAtual >= 2 && caixas.Length > 0)
            {
            GameObject.Find("NavMesh").GetComponent<NavMeshTest>().DestinoInimigo();

            iconFaca.SetActive(true);

            foreach (GameObject caixa in caixas)
            {
                CutCaixa cutCaixas = caixa.GetComponent<CutCaixa>();

                if (cutCaixas != null)
                {
                    cutCaixas.podeQuebrar = true;
                }
            }
        }

        if (valorBarraAtual == 4)
        {
            AcabarJogo();
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

    public void AcabarJogo()
    {
            Debug.Log("final");

            GameObject.Find("PauseManager").GetComponent<Pause>().TogglePause();
            canvaMorte.SetActive(true);
            canvaMorte.GetComponent<MenuERestart>().AtivarMouse();
    }
}