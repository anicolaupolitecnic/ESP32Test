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
    [SerializeField] private float totalDistance = 5;

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
        lastBullseye = transform.position;
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
        if (currentDistance > totalDistance)
        {
            Vector3 vect = player.position - transform.position;
            vect = vect.normalized;
            vect *= (currentDistance - totalDistance);
            transform.position += vect;
        }
    }

    private void SpawnBullseye()
    {
        if (firstSpawn)
        {
            lastBullseye = transform.position;
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
            transform.position += xPosition + yPosition + zPosition;
            //new Vector3 (lastBullseye.position.x + xDistanceNext, lastBullseye.position.y + yDistanceNext, player.position.z + zDistance);
            lastBullseye = transform.position;
            GameObject bullseye = Instantiate(bullseyePrefab, transform.position, Quaternion.identity);
            //player.LookAt(bullseye.transform);
            bullseye.transform.LookAt(player);
            Destroy(bullseye, bullseyeTime);
        }
        
    }
}
