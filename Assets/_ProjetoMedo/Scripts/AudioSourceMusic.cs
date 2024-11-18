using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceMusic : MonoBehaviour
{
    public AudioClip[] musicas;

    private AudioSource emissor;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        emissor = GetComponent<AudioSource>();

        emissor.mute = PlayerPrefs.GetInt("MuteMusic", 0) == 1;

        TemaMenu();
    }

    public void MuteMusic()
    {
        emissor.mute = !emissor.mute;

        PlayerPrefs.SetInt("MuteMusic", emissor.mute ? 1 : 0);
        PlayerPrefs.Save();

        TemaMenu();
    }
    public void TemaJogo()
    {
        if (!emissor.mute)
        {
            TocarMusica(0);
        }
    }

    public void TemaPersseguicao()
    {
        if (!emissor.mute)
        {
            TocarMusica(1);
        }
    }

    public void TemaMenu()
    {
        if (!emissor.mute)
        {
            TocarMusica(2);
        }
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