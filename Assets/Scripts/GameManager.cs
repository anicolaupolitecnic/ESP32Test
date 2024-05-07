using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static DianaController;

public class GameManager : MonoBehaviour
{
    // No canviar ordre de textMesh del ispector
    [SerializeField] private List<TextMeshProUGUI> puntuationTextList;

    [Header("Panels HUD")]
    [SerializeField] private GameObject finalScorePanel;
    [SerializeField] private GameObject scorePanel;
    [SerializeField] private GameObject timePanel;
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private Button btnReplay;

    [Header("Timer Settings")]
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timeRemaining = 90;

    [Header("Score Puntuation")]
    [SerializeField] private int bad;
    [SerializeField] private int good;
    [SerializeField] private int veryGood;
    [SerializeField] private int perfect;
    [SerializeField] private int gold;
    [SerializeField] private int miss;

    [Header("High Score")]
    [SerializeField] private SCOHighscore highscore;
    [SerializeField] private GameObject textHighScore;

    [Header("Final Score Texts")]
    [Header("Nº Hits")]
    [SerializeField] private TextMeshProUGUI nhitsBad;
    [SerializeField] private TextMeshProUGUI nhitsGood;
    [SerializeField] private TextMeshProUGUI nhitsVeryGood;
    [SerializeField] private TextMeshProUGUI nhitsPerfect;
    [SerializeField] private TextMeshProUGUI nhitsGold;
    [SerializeField] private TextMeshProUGUI nhitsMiss;

    [Header("Points")]
    [SerializeField] private TextMeshProUGUI pointsBad;
    [SerializeField] private TextMeshProUGUI pointsGood;
    [SerializeField] private TextMeshProUGUI pointsVeryGood;
    [SerializeField] private TextMeshProUGUI pointsPerfect;
    [SerializeField] private TextMeshProUGUI pointsGold;
    [SerializeField] private TextMeshProUGUI pointsMiss;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreBad;
    [SerializeField] private TextMeshProUGUI scoreGood;
    [SerializeField] private TextMeshProUGUI scoreVeryGood;
    [SerializeField] private TextMeshProUGUI scorePerfect;
    [SerializeField] private TextMeshProUGUI scoreGold;
    [SerializeField] private TextMeshProUGUI scoreMiss;
    [SerializeField] private TextMeshProUGUI scoreTotal;


    private bool timerIsRunning = true;

    private Dictionary<PointsHit, TextMeshProUGUI> canvasPuntuation;
    private Dictionary<PointsHit, int> puntuationList;
    private Dictionary<PointsHit, int> scoreList;
    private Dictionary<PointsHit, int> finalScoreList;

    private int count = 0;
    private int finalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        puntuationList = new Dictionary<PointsHit, int>();
        canvasPuntuation = new Dictionary<PointsHit, TextMeshProUGUI>();
        scoreList = new Dictionary<PointsHit, int>();
        finalScoreList = new Dictionary<PointsHit, int>();
        foreach (PointsHit typePoint in Enum.GetValues(typeof(PointsHit)))
        {
            puntuationList.Add(typePoint, 0);
            canvasPuntuation.Add(typePoint, puntuationTextList[count]);
            switch (typePoint)
            {
                case PointsHit.Bad:
                    scoreList.Add(typePoint, bad);
                    break;

                case PointsHit.Good:
                    scoreList.Add(typePoint, good);
                    break;

                case PointsHit.VeryGood:
                    scoreList.Add(typePoint, veryGood);
                    break;

                case PointsHit.Perfect:
                    scoreList.Add(typePoint, perfect);
                    break;

                case PointsHit.Gold:
                    scoreList.Add(typePoint, gold);
                    break;
                case PointsHit.Miss:
                    scoreList.Add(typePoint, miss);
                    break;
            }
            count++;
        }

        btnReplay.onClick.AddListener(() =>
            SceneManager.LoadScene(0)
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                SumFinalScore();
                timePanel.SetActive(false);
                scorePanel.SetActive(false);
                ShowFinalSore();
            }
        }
    }

    public void SetNewPuntuation(PointsHit pointType)
    {
        puntuationList[pointType]++;
        canvasPuntuation[pointType].text = puntuationList[pointType].ToString();
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void SumFinalScore()
    {
        foreach (KeyValuePair<PointsHit, int> kvp in puntuationList)
        {
            finalScoreList[kvp.Key] = scoreList[kvp.Key] * kvp.Value;
            finalScore += scoreList[kvp.Key] * kvp.Value;
        }
    }

    private void ShowFinalSore()
    {
        foreach (KeyValuePair<PointsHit, int> kvp in puntuationList)
        {
            switch (kvp.Key)
            {
                case PointsHit.Bad:
                    nhitsBad.text = puntuationList[kvp.Key].ToString();
                    pointsBad.text = scoreList[kvp.Key].ToString();
                    scoreBad.text = finalScoreList[kvp.Key].ToString();
                    break;

                case PointsHit.Good:
                    nhitsGood.text = puntuationList[kvp.Key].ToString();
                    pointsGood.text = scoreList[kvp.Key].ToString();
                    scoreGood.text = finalScoreList[kvp.Key].ToString();
                    break;

                case PointsHit.VeryGood:
                    nhitsVeryGood.text = puntuationList[kvp.Key].ToString();
                    pointsVeryGood.text = scoreList[kvp.Key].ToString();
                    scoreVeryGood.text = finalScoreList[kvp.Key].ToString();
                    break;

                case PointsHit.Perfect:
                    nhitsPerfect.text = puntuationList[kvp.Key].ToString();
                    pointsPerfect.text = scoreList[kvp.Key].ToString();
                    scorePerfect.text = finalScoreList[kvp.Key].ToString();
                    break;

                case PointsHit.Gold:
                    nhitsGold.text = puntuationList[kvp.Key].ToString();
                    pointsGold.text = scoreList[kvp.Key].ToString();
                    scoreGold.text = finalScoreList[kvp.Key].ToString();
                    break;
                case PointsHit.Miss:
                    nhitsMiss.text = puntuationList[kvp.Key].ToString();
                    pointsMiss.text = scoreList[kvp.Key].ToString();
                    scoreMiss.text = finalScoreList[kvp.Key].ToString();
                    break;
            }
        }
        scoreTotal.text = finalScore.ToString();
        if (highscore.highscoreGame < finalScore)
        {
            highscore.highscoreGame = finalScore;
            textHighScore.SetActive(true);
        }
        finalScorePanel.SetActive(true);
        buttonPanel.SetActive(true);
    }
}
