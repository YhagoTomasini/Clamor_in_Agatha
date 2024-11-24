using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CinematicFinal : MonoBehaviour
{
    public GameObject pInicial;
    public GameObject pFinal;
    public GameObject canvaFim;

    public float duracao = 10f;
    public ScriptableRendererFeature lineRender;

    public Image whiteBlur;

    void Start()
    {
        canvaFim.SetActive(false);

        whiteBlur.gameObject.SetActive(true);

        if (lineRender != null)
        {
            lineRender.SetActive(false);
        }

        pInicial = GameObject.Find("posicaoI");
        pFinal = GameObject.Find("posicaoF");

        StartCoroutine(MovimentoCam(8f));

    }

    IEnumerator MovimentoCam(float duracaoFade)
    {
        whiteBlur.gameObject.SetActive(true);
        Color blurColor = whiteBlur.color;

        whiteBlur.color = blurColor;
        
        yield return new WaitForSeconds(2f);

        GameObject.Find("AudioMusicManager").GetComponent<AudioSourceMusic>().TemaFinal();

        float duracaoBlur = 0f;
        while (duracaoBlur < duracaoFade)
        {
            blurColor.a = Mathf.Lerp(1f, 0f, duracaoBlur / duracaoFade);
            whiteBlur.color = blurColor;
            duracaoBlur += Time.deltaTime;

            yield return null;
        }

        whiteBlur.gameObject.SetActive(false);

        yield return new WaitForSeconds(2f);
        
        float elapsedTime = 0f;

        while (elapsedTime < duracao)
        {
            float t = elapsedTime / duracao;
            transform.position = Vector3.Lerp(pInicial.transform.position, pFinal.transform.position, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = pFinal.transform.position;

        yield return new WaitForSeconds(2f);
        //SceneManager.LoadScene("UiGame");

        canvaFim.SetActive(true);
        GameObject.Find("AudioMusicManager").GetComponent<AudioSourceMusic>().PararMusica();
        Cursor.lockState = CursorLockMode.None;

    }

    void Update()
    {
        
    }
}
