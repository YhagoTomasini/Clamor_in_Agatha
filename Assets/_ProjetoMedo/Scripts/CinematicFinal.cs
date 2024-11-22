using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CinematicFinal : MonoBehaviour
{
    public GameObject pInicial;
    public GameObject pFinal;

    public float duracao = 5f;
    public ScriptableRendererFeature lineRender;

    void Start()
    {
        if (lineRender != null)
        {
            lineRender.SetActive(false);
        }
        //GameObject.Find("AudioMusicManager").GetComponent<AudioSourceMusic>().TemaMenu();
        pInicial = GameObject.Find("posicaoI");
        pFinal = GameObject.Find("posicaoF");

        StartCoroutine(MovimentoCam());

    }

    IEnumerator MovimentoCam()
    {
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
