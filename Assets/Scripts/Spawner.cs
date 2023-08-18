using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject waveOne;
    public GameObject waveTwo;
    public GameObject waveFour;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveOne());
        StartCoroutine(WaveTwo());
        StartCoroutine(WaveThree());
        StartCoroutine(WaveFour());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaveOne()
    {

        yield return new WaitForSeconds(2f);

        Instantiate(waveOne, waveOne.transform.position, waveOne.transform.rotation);
    }

    IEnumerator WaveTwo()
    {

        yield return new WaitForSeconds(20f);

        Instantiate(waveTwo, waveTwo.transform.position, waveTwo.transform.rotation);
    }

    IEnumerator WaveThree()
    {

        yield return new WaitForSeconds(30f);
        
        Instantiate(waveOne, waveOne.transform.position, waveOne.transform.rotation);
        Instantiate(waveTwo, waveTwo.transform.position, waveTwo.transform.rotation);
    }

    IEnumerator WaveFour()
    {

        yield return new WaitForSeconds(50f);

        Instantiate(waveFour, waveFour.transform.position, waveFour.transform.rotation);
    }
}
