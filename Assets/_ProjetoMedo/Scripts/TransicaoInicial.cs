using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class TransicaoInicial : MonoBehaviour
{
    public ScriptableRendererFeature lineRender;

    void Start()
    {
        if (lineRender != null)
        {
            lineRender.SetActive(true);
        }
        StartCoroutine(IniciarJogo());
    }

    IEnumerator IniciarJogo()
    {
        yield return new WaitForSeconds(0.1f);
        //SceneManager.LoadScene("oJogo");
        //SceneManager.LoadScene("FinalCutscene");
        SceneManager.LoadScene("UiGame");
    }
}
   