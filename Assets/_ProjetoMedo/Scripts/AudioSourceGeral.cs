using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioSourceGeral : MonoBehaviour
{
    public AudioClip[] sons;

    private AudioSource emissor;

    // Start is called before the first frame update
    void Start()
    {
        emissor = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SomCut()
    {
        AudioClip audioDaVez = sons[0];
        emissor.PlayOneShot(audioDaVez);
    }
    public void SomBuff()
    {
        AudioClip audioDaVez = sons[1];
        emissor.PlayOneShot(audioDaVez);
    }
    public void SomInimSteps()
    {
        AudioClip audioDaVez = sons[2];
        emissor.PlayOneShot(audioDaVez);
    }
    public void SomSonar()
    {
        AudioClip audioDaVez = sons[Random.Range(3, 5)];
        emissor.PlayOneShot(audioDaVez);
    }
}
