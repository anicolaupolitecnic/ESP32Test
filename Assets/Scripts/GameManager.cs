using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Dictionary<DianaController.PointsHit, int> puntuationList;

    // Start is called before the first frame update
    void Start()
    {
        puntuationList = new Dictionary<DianaController.PointsHit, int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Pensar com emplear enum perque sigui un array
    public void SetNewPuntuation(DianaController.PointsHit pointType)
    {
        puntuationList[pointType]++;
    }
}
