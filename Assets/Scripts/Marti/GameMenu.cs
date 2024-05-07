using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMenu : MonoBehaviour
{
    //Aixo auria de estar a nes sound manager.
    private float soundVolume;
    [SerializeField] SoundLibrary soundLibrary;


    [SerializeField] private GameObject principalMenu;
    [SerializeField] private GameObject highscoreMenu;

    [SerializeField] private TextMeshProUGUI textHighscore;
    [SerializeField] private SCOHighscore scoHighscore;

    //Obrir Scene Joc
    public void StartGame()
    {
        Debug.Log("StartGame");
        SceneManager.LoadScene("MasterScene");
    }

    //Tancar Menu Puntuacio
    public void CloseMenuHighScore()
    {
        highscoreMenu.SetActive(false);
        principalMenu.SetActive(true);
    }

    //Obrir Menu Puntuacio
    public void OpenMenuHighScore()
    {
        Debug.Log("MenuHighAbierto");
        highscoreMenu.SetActive(true);
        textHighscore.text = "HIGHSCORE: " + scoHighscore.highscoreGame.ToString();
        principalMenu.SetActive(false);
    }

    //Sortir Joc
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
