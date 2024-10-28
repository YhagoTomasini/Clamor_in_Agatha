using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ondaSom : MonoBehaviour
{
    public GameObject onda;

    public Vector3 scaleOndaI = new Vector3(2f, 2f, 2f);
    public Vector3 scaleOndaF = new Vector3(20f, 20f, 20f);

    public float delayVelo;
    public float scaleVelo = 2f;

    public bool podeSonar = true;

    private void Start()
    {
        Vector3 pposition = transform.position;

        GameObject newOnda = Instantiate(onda, pposition, Quaternion.identity);

        newOnda.transform.localScale = scaleOndaI;

        StartCoroutine(CrescerAteMorrer(newOnda));

        delayVelo = 1f;
    }
    void Update()
    {
        Vector3 pposition = transform.position;
        if (podeSonar)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.F))
            {
                GameObject newOnda = Instantiate(onda, pposition, Quaternion.identity);

                newOnda.transform.localScale = scaleOndaI;
                StartCoroutine(DelayOnda());
                StartCoroutine(CrescerAteMorrer(newOnda));
            }
        }
    }

    IEnumerator DelayOnda()
    {
        podeSonar = false;
        yield return new WaitForSeconds(delayVelo);
        podeSonar = true;
        yield return null;
    }
    IEnumerator CrescerAteMorrer(GameObject objeto)
    {
        float tempo = 0f;

        while (tempo<scaleVelo)
        {
            tempo += Time.deltaTime;

            objeto.transform.localScale = Vector3.Lerp(scaleOndaI, scaleOndaF, tempo / scaleVelo);
            

            yield return null;
        }
        Destroy (objeto);
    }
}
