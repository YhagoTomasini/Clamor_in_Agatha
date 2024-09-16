using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animBuff : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float velocidade = 1f;
    private Vector3 posicaoInicial;

    void Start()
    {
        posicaoInicial = transform.position;
    }

    void Update()
    {
        Vector3 novaPosicao = posicaoInicial;
        novaPosicao.y += Mathf.Sin(Time.time * velocidade) * amplitude;

        transform.position = novaPosicao;
    }
}