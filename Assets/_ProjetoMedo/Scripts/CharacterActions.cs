using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
//using UnityEngine.Windows;

public class CharacterActs : MonoBehaviour
{
    public GameObject caixas;
    public GameObject pulos;

    public GameObject barraCanva;
    public RectTransform rectBarra;
    public float valorbarraNor;
    public float valorBarraAtual;
    private float valorBarraMax = 12;

    public Image whiteBlur;

    public GameObject aCoisa;
    public GameObject canvaMorte;

    public float delayVelo = 1f;

    public GameObject iconPulo;
    public GameObject iconFaca;

    public GameObject iconFacaOn;
    public GameObject iconPuloOn;

    private bool podeSeguir;

    void Start()
    {
        whiteBlur.gameObject.SetActive(false);

        //canvaMorte = GameObject.Find("CanvasRestart");
        //canvaMorte.SetActive(false);


        iconFaca = GameObject.Find("IconFaca");
        iconFacaOn = GameObject.Find("IconFacaOn");
        iconFaca.SetActive(false);
        iconFacaOn.SetActive(false);

        iconPulo = GameObject.Find("IconPulo");
        iconPuloOn = GameObject.Find("IconPuloOn");
        iconPulo.SetActive(false);
        iconPuloOn.SetActive(false);

        podeSeguir = true;
                
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

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.K))
    //    {
    //        Debug.Log("KKKK");
    //        StartCoroutine(IconFaca());
    //    }
    //}

    public void FuncFaca()
    {
        StartCoroutine(IconFaca());
    }
    public IEnumerator IconFaca()
    {
        Debug.Log("Ativando ícone da faca");
        iconFacaOn.SetActive(true);

        yield return new WaitForSeconds(delayVelo);
        Debug.Log("Desativando ícone da faca");
        iconFacaOn.SetActive(false);

        yield return null;
    }

    public void FuncPulo()
    {
        StartCoroutine(IconPulo());
    }
    public IEnumerator IconPulo()
    {
        iconPuloOn.SetActive(true);

        yield return new WaitForSeconds(delayVelo);
        iconPuloOn.SetActive(false);

        yield return null;
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
            GameObject.Find("AudioEffectsManager").GetComponent<AudioSourceGeral>().SomBuff();

            progredirBarra();
            StartCoroutine (EfeitoBuff(1f));

            if (other != null)
            {
                Destroy(other.gameObject);
            }
        }


        if (valorBarraAtual >= 2 && caixas!=null)
        {
            if (valorBarraAtual == 2 && podeSeguir)
            {
                Instantiate(aCoisa, new Vector3(-16f, 3.75f, -16f), Quaternion.identity);
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

        if (valorBarraAtual >= 5 && pulos != null)
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


        if (other.CompareTag("FCD"))
        {
            AcabarJogo();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (pulos != null)
        //{
        //    foreach (Transform child in pulos.transform)
        //    {
        //        JumpUp jumpUp = child.GetComponent<JumpUp>();

        //        if (jumpUp != null)
        //        {
        //            jumpUp.DefinirColliders(null);
        //        }
        //    }
        //}
    }


    public void AcabarJogo()
    {
        Debug.Log("final");

        GameObject.Find("PauseManager").GetComponent<Pause>().TogglePause();
        canvaMorte.SetActive(true);
    }
}