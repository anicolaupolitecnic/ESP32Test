using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> puntuationTextList;

    private Dictionary<DianaController.PointsHit, TextMeshProUGUI> canvasPuntuation;
    private Dictionary<DianaController.PointsHit, int> puntuationList;

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        puntuationList = new Dictionary<DianaController.PointsHit, int>();
        canvasPuntuation = new Dictionary<DianaController.PointsHit, TextMeshProUGUI>();
        foreach (DianaController.PointsHit typePoint in Enum.GetValues(typeof(DianaController.PointsHit)))
        {
            puntuationList.Add(typePoint, 0);
            canvasPuntuation.Add(typePoint, puntuationTextList[count]);
            Debug.Log(typePoint + " " + canvasPuntuation[typePoint].gameObject.ToString());
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNewPuntuation(DianaController.PointsHit pointType)
    {
        puntuationList[pointType]++;
        canvasPuntuation[pointType].text = puntuationList[pointType].ToString();
        Debug.Log(pointType + ": " + puntuationList[pointType]);
    }
}
