using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicaoInicial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IniciarJogo());
    }

    IEnumerator IniciarJogo()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("UiGame");
    }
}
   