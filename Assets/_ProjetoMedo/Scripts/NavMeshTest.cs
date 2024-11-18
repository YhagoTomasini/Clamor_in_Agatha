using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{

    public NavMeshAgent meuAgente;
    public Transform destino;
    public Vector3 destinoAtual;

    public bool andando = false;
    private Coroutine passosCoroutine;

    private void Start()
    {

        //    StartCoroutine(AndaleAndale());
        //}

        //IEnumerator AndaleAndale()
        //{
        //    while (true)
        //    {
        //        DestinoInimigo();

        //        yield return new WaitForSeconds(4f);
        //    }
    }

    private void Update()
    {
        destinoAtual = destino.position;

        if (andando)
        {
            if (!meuAgente.pathPending &&
                meuAgente.remainingDistance <= meuAgente.stoppingDistance &&
                meuAgente.velocity.sqrMagnitude < 0.01f)
            {
                if (andando)
                {
                    andando = false;
                    TrocarMusica();
                    if (passosCoroutine != null)
                    {
                        StopCoroutine(passosCoroutine);
                        passosCoroutine = null;
                    }
                }
            }
        }
    }
    void TrocarMusica()
    {
        GameObject.Find("AudioMusicManager").GetComponent<AudioSourceMusic>().TemaJogo();
    }
    public void DestinoInimigo()
    {
        GameObject.Find("AudioMusicManager").GetComponent<AudioSourceMusic>().TemaPersseguicao();

        meuAgente = GameObject.Find("Inimigo(Clone)").GetComponent<NavMeshAgent>();

        meuAgente.SetDestination(destinoAtual);
        andando = true;

        if (passosCoroutine == null)
        {
            passosCoroutine = StartCoroutine(AtivarPassos());
        }
    }

    IEnumerator AtivarPassos()
    {
        while (andando)
        {
            GameObject.Find("AudioEffectsManager").GetComponent<AudioSourceGeral>().SomInimSteps();
            GameObject.Find("Inimigo(Clone)").GetComponent<ondaCoisa>().Andando();
            yield return new WaitForSeconds(4f);
        }
    }
}
