using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDrop : MonoBehaviour
{
    public static PickupDrop instance;

    // This array will hold the checkpoints in the coresponding level
    public GameObject[] pickups;
    
    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetRandomPickupGuaranteed(Transform spawnLocation)
    {
        int randomPickupNumber = Random.Range(0, pickups.Length-1);
        Instantiate(pickups[randomPickupNumber], spawnLocation.position, new Quaternion(0,0,0,0));
    }

    public void GetRandomPickupProbability(int probability, Transform spawnLocation)
    {
        int randomProbability = Random.Range(0,100);
        if(randomProbability <= probability)
        {
            int randomPickupNumber = Random.Range(0, pickups.Length-1);
            Instantiate(pickups[randomPickupNumber], spawnLocation.position, new Quaternion(0,0,0,0));
        }
    }

    public void GetSelectedDrop(int dropNumber, Transform spawnLocation)
    {
        if (dropNumber < pickups.Length)
        {
            Instantiate(pickups[dropNumber], spawnLocation.position, new Quaternion(0,0,0,0));
        }
    }
}
