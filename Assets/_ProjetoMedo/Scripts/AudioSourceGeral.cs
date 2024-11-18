using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
