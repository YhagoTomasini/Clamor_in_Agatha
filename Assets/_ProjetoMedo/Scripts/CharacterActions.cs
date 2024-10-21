using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class CharacterActs : MonoBehaviour
{
    //public GameObject[] caixas;

    public GameObject caixas;
    public GameObject pulos;

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

    private bool podeSeguir;

    void Start()
    {
        whiteBlur.gameObject.SetActive(false);

        canvaMorte = GameObject.Find("CanvasRestart");
        iconFaca = GameObject.Find("IconFaca");
        iconPulo = GameObject.Find("IconPulo");
        iconShrek = GameObject.Find("IconShrek");

        canvaMorte.SetActive(false);
        iconFaca.SetActive(false);
        iconPulo.SetActive(false); 
        iconShrek.SetActive(false);

        podeSeguir = false;

        //caixas = GameObject.FindGameObjectsWithTag("Caixas");
        
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

        whiteBlur.color = blurColor;

        float duracao = 0f;
        while (duracao < duracaoFade)
        {
            blurColor.a = Mathf.Lerp(1f, 0f, duracao / duracaoFade);
            whiteBlur.color = blurColor;
            duracao += Time.deltaTime;

            yield return null;
        }

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
            StartCoroutine (EfeitoBuff(1f));

            if (other != null)
            {
                Destroy(other.gameObject);
            }
        }


        if (valorBarraAtual >= 2 && caixas!=null)
        {
            if (valorBarraAtual == 2)
            {
                podeSeguir = true;
            }
            if (podeSeguir)
            {
                GameObject.Find("NavMesh").GetComponent<NavMeshTest>().DestinoInimigo();
                podeSeguir = false;
            }

            iconFaca.SetActive(true);

            if (caixas != null)
            {
                foreach (Transform child in caixas.transform)
                {
                    CutCaixa cutCaixas = child.GetComponent<CutCaixa>();

                    if (cutCaixas != null)
                    {
                        cutCaixas.podeQuebrar = true;
                    }
                }
            }
        }

        if (valorBarraAtual >= 3 && pulos != null)
        {
            iconPulo.SetActive(true);

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

            //GameObject.Find("PauseManager").GetComponent<Pause>().TogglePause();
            canvaMorte.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
    }
}