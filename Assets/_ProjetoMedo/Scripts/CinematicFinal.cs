using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class CinematicFinal : MonoBehaviour
{
    public GameObject pInicial;
    public GameObject pFinal;

    public float duracao = 5f;
    public ScriptableRendererFeature lineRender;

    public Image whiteBlur;

    void Start()
    {
        whiteBlur.gameObject.SetActive(true);

        if (lineRender != null)
        {
            lineRender.SetActive(false);
        }
        GameObject.Find("AudioMusicManager").GetComponent<AudioSourceMusic>().TemaMenu();
        pInicial = GameObject.Find("posicaoI");
        pFinal = GameObject.Find("posicaoF");

        StartCoroutine(MovimentoCam(2f));

    }

    IEnumerator MovimentoCam(float duracaoFade)
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

        yield return new WaitForSeconds(0.1f);
        float elapsedTime = 0f;

        while (elapsedTime < duracao)
        {
            float t = elapsedTime / duracao;
            transform.position = Vector3.Lerp(pInicial.transform.position, pFinal.transform.position, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = pFinal.transform.position;
    }

    void Update()
    {
        
    }
}
