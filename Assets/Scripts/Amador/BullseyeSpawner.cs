using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BullseyeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bullseyePrefab;
    [SerializeField] private Transform player;

    [SerializeField] private float xDistance = 5;
    [SerializeField] private float yDistance = 5;
    [SerializeField] private float zDistance = 5;

    private float[] xDistancePossibilities;
    private float[] yDistancePossibilities;
    private float[] zDistancePossibilities;

    [SerializeField] private float bullseyeTime;
    [SerializeField] private float spawnTime = 3;
    [SerializeField] private float minDistance = 3;
    [SerializeField] private float maxDistance = 5;

    private float timer = 0;
    private Vector3 lastBullseye;

    private bool firstSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        xDistancePossibilities = new float[]
        {
            xDistance,
            -xDistance
        };
        yDistancePossibilities = new float[]
        {
            yDistance,
            -yDistance
        };
        zDistancePossibilities = new float[]
        {
             zDistance,
            -zDistance
        };
        lastBullseye = transform.localPosition;
        SpawnBullseye();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnBullseye();
            timer = 0;
        }

        float currentDistance = Vector3.Distance(player.position, transform.position);
        Debug.Log(currentDistance);
        if (currentDistance > maxDistance)
        {
            Vector3 vect = player.position - transform.position;
            vect = vect.normalized;
            vect *= (currentDistance - maxDistance);
            transform.position += vect;
        }else if(currentDistance < minDistance)
        {
            Vector3 vect = player.position - transform.position;
            vect = vect.normalized;
            vect *= (currentDistance + minDistance);
            transform.position += vect;
        }
    }

    private void SpawnBullseye()
    {
        if (firstSpawn)
        {
            lastBullseye = transform.localPosition;
            GameObject bullseye = Instantiate(bullseyePrefab, transform.position, Quaternion.identity);
            bullseye.transform.LookAt(player);
            Destroy(bullseye, bullseyeTime);
            firstSpawn = false;
        }
        else
        {
            float xDistanceNext = xDistancePossibilities[Random.Range(0, xDistancePossibilities.Length)];
            float yDistanceNext = yDistancePossibilities[Random.Range(0, yDistancePossibilities.Length)];
            float zDistanceNext = zDistancePossibilities[Random.Range(0, zDistancePossibilities.Length)];
            Vector3 xPosition = transform.right * xDistanceNext;
            Vector3 yPosition = transform.up * yDistanceNext;
            Vector3 zPosition = transform.forward * zDistanceNext;
            transform.localPosition += xPosition + yPosition + zPosition;
            transform.LookAt(player);
            lastBullseye = transform.localPosition;
            GameObject bullseye = Instantiate(bullseyePrefab, transform.localPosition, transform.rotation);
            //player.LookAt(bullseye.transform);
            //bullseye.transform.LookAt(player);
            Destroy(bullseye, bullseyeTime);
        }        
    }
}
