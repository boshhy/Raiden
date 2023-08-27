using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject waveOne;
    public GameObject waveTwo;
    public GameObject waveThree;
    public GameObject waveFour;
    public GameObject waveFive;


    public GameObject FirstWaveCredits;
    public GameObject SecondWaveCredits;
    public GameObject ThirdWaveCreditsPartA;
    public GameObject ThirdWaveCreditsPartB;

    public GameObject FifthWaveCreditsPartA;
    public GameObject FifthWaveCreditsPartB;
    public GameObject FifthWaveCreditsPartC;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveOne());
        StartCoroutine(WaveTwo());
        StartCoroutine(WaveThree());
        StartCoroutine(WaveFour());
        StartCoroutine(WaveFive());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaveOne()
    {

        yield return new WaitForSeconds(9f);

        Instantiate(waveOne, waveOne.transform.position, waveOne.transform.rotation);
        FirstWaveCredits.SetActive(true);
    }

    IEnumerator WaveTwo()
    {

        yield return new WaitForSeconds(27f);

        Instantiate(waveTwo, waveTwo.transform.position, waveTwo.transform.rotation);
        SecondWaveCredits.SetActive(true);
    }

    IEnumerator WaveThree()
    {

        yield return new WaitForSeconds(37f);
        
        Instantiate(waveThree, waveThree.transform.position, waveThree.transform.rotation);
        ThirdWaveCreditsPartA.SetActive(true);
        ThirdWaveCreditsPartB.SetActive(true);
    }

    IEnumerator WaveFour()
    {

        yield return new WaitForSeconds(57f);

        Instantiate(waveFour, waveFour.transform.position, waveFour.transform.rotation);
    }
    
    IEnumerator WaveFive()
    {

        yield return new WaitForSeconds(84f);

        Instantiate(waveFive, waveFive.transform.position, waveFive.transform.rotation);
        FifthWaveCreditsPartA.SetActive(true);
        FifthWaveCreditsPartB.SetActive(true);
        FifthWaveCreditsPartC.SetActive(true);
    }
}
