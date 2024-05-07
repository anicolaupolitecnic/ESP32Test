using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullseye : MonoBehaviour
{
    private BullseyeSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("BullseyeSpawner").GetComponent<BullseyeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnAnother()
    {
        spawner.SpawnBullseye();
    }
}
