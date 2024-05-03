using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaController : MonoBehaviour
{
    [SerializeField] private PointsHit pointType;

    [Serializable]
    public enum PointsHit
    {
        Bad,
        Good,
        VeryGood,
        Perfect,
        Gold,
        Miss
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PointsHit GetPointType()
    {
        return pointType;
    }
}
