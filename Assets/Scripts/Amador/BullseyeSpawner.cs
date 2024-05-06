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

    [SerializeField] private float xDistanceMove = 5;
    [SerializeField] private float yDistanceMove = 5;
    [SerializeField] private float zDistance = 5;

    private float[] xDistancePossibilities;
    private float[] yDistancePossibilities;
    private float[] zDistancePossibilities;

    [SerializeField] private float bullseyeTime;
    [SerializeField] private float spawnTime = 3;

    [SerializeField] private float maxYDistance = 10;

    //[SerializeField] private float minDistance = 3;
    //[SerializeField] private float maxzDistance = 5;

    private float timer = 0;
    //private Vector3 lastBullseye;

    private bool firstSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        xDistancePossibilities = new float[]
        {
            xDistanceMove,
            -xDistanceMove
        };
        yDistancePossibilities = new float[]
        {
            yDistanceMove,
            -yDistanceMove
        };
        //zDistancePossibilities = new float[]
        //{
        //     zDistance,
        //    -zDistance
        //};
        transform.position = player.forward * zDistance;
        //lastBullseye = transform.position;
        SpawnBullseye();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            SpawnBullseye();
        }

        //float currentDistance = Vector3.Distance(player.position, transform.position);
        //Debug.Log(currentDistance);

        Vector3 localPos = transform.localPosition;
        if(localPos.z != zDistance)
        {
            localPos.z = zDistance;
            transform.localPosition = localPos;
            Debug.Log(transform.localPosition);
        }

        Vector3 pos = transform.position;
        if(transform.position.y > maxYDistance)
        {
            pos.y = maxYDistance;
            transform.position = pos;
        }else if(transform.position.y < -maxYDistance)
        {
            pos.y = -maxYDistance;
            transform.position = pos;
        }

        //if (currentDistance > maxDistance)
        //{
        //    Vector3 vect = player.position - transform.position;
        //    vect = vect.normalized;
        //    vect *= (currentDistance - maxDistance);
        //    transform.position += vect;
        //}else if(currentDistance < minDistance)
        //{
        //    Vector3 vect = player.position - transform.position;
        //    vect = vect.normalized;
        //    vect *= (currentDistance + minDistance);
        //    transform.position += vect;
        //}
    }

    private void SpawnBullseye()
    {
        if (firstSpawn)
        {
            //lastBullseye = transform.localPosition;
            GameObject bullseye = Instantiate(bullseyePrefab, transform.position, Quaternion.identity);
            bullseye.transform.LookAt(player);
            Destroy(bullseye, bullseyeTime);
            firstSpawn = false;
        }
        else
        {
            float xDistanceNext = xDistancePossibilities[Random.Range(0, xDistancePossibilities.Length)];
            float yDistanceNext = yDistancePossibilities[Random.Range(0, yDistancePossibilities.Length)];
            //float zDistanceNext = zDistancePossibilities[Random.Range(0, zDistancePossibilities.Length)];
            Vector3 xPosition = transform.right * xDistanceNext;
            Vector3 yPosition = transform.up * yDistanceNext;
            //Vector3 zPosition = transform.forward * zDistanceNext;
            transform.localPosition += xPosition + yPosition;
            transform.LookAt(player);
            //lastBullseye = transform.position;
            GameObject bullseye = Instantiate(bullseyePrefab, transform.position, transform.rotation);
            //player.LookAt(bullseye.transform);
            Destroy(bullseye, bullseyeTime);
        }
    timer = 0;
    }
}
