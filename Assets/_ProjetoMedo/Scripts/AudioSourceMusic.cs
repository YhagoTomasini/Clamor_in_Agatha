using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceMusic : MonoBehaviour
{
    public AudioClip[] musicas;

    private AudioSource emissor;

    // Start is called before the first frame update
    void Start()
    {
        emissor = GetComponent<AudioSource>();
        TemaJogo();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TemaJogo()
    {
        TocarMusica(0);
    }

    public void TemaPersseguicao()
    {
        TocarMusica(1);
    }
    public void TemaMenu()
    {
        TocarMusica(2);
    }

    private void TocarMusica(int indice)
    {
        if (emissor.isPlaying)
        {
            emissor.Stop();
        }

        emissor.clip = musicas[indice];
        emissor.Play();
    }

}