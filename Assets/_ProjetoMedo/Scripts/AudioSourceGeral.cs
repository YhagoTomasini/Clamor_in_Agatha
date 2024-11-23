using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioSourceGeral : MonoBehaviour
{
    public AudioClip[] sons;

    private AudioSource emissor;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        emissor = GetComponent<AudioSource>();

        emissor.mute = PlayerPrefs.GetInt("MuteEffects", 0) == 1;
    }

    public void MuteEffects()
    {
        emissor.mute = !emissor.mute;

        PlayerPrefs.SetInt("MuteEffects", emissor.mute ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SomCut()
    {
        TocarSom(0);
    }

    public void SomBuff()
    {
        TocarSom(1);
    }

    public void SomInimSteps()
    {
        TocarSom(2);
    }

    public void SomSonar()
    {
        TocarSom(Random.Range(3, 5));
    }

    public void SomBotao()
    {
        TocarSom(6);
    }

    public void SomPassos()
    {
        TocarSom(Random.Range(7, 9));
    }
    public void SomQueda()
    {
        TocarSom(Random.Range(10, 12));
    }
    private void TocarSom(int indice)
    {
        if (!emissor.mute && indice >= 0 && indice < sons.Length)
        {
            AudioClip audioDaVez = sons[indice];
            emissor.PlayOneShot(audioDaVez);
        }
    }
}
