using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DianaController : MonoBehaviour
{
    [SerializeField] private PointsHit pointType;

    public enum PointsHit
    {
        Bad,
        Good,
        VeryGood,
        Perfect,
        Gold
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
