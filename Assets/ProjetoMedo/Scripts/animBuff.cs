using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animBuff : MonoBehaviour
{
    public float amplitude = 0.1f;
    public float velocidade = 1f;
    public float escalaAmplitude = 0.1f;
    public float escalaVelocidade = 1f;

    private Vector3 posicaoInicial;
    private Vector3 escalaInicial;

    void Start()
    {
        posicaoInicial = transform.position;
        escalaInicial = transform.localScale;
    }

    void Update()
    {
        Vector3 novaPosicao = posicaoInicial;
        novaPosicao.y += Mathf.Sin(Time.time * velocidade) * amplitude;
        transform.position = novaPosicao;

        float escalaFator = 1 + Mathf.Sin(Time.time * escalaVelocidade) * escalaAmplitude;
        transform.localScale = escalaInicial * escalaFator;
    }
}