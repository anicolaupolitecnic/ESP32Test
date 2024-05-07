using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameMenu : MonoBehaviour
{
    //Aixo auria de estar a nes sound manager.
    private float soundVolume;
    [SerializeField] SoundLibrary soundLibrary;


    [SerializeField] private GameObject principalMenu;
    [SerializeField] private GameObject highscoreMenu;

    //Obrir Scene Joc
    public void StartGame()
    {
        Debug.Log("StartGame");
        //SceneManager.LoadScene("PlayerSelection");
    }

    //Tancar Menu Puntuacio
    public void CloseMenuHighScore()
    {
        highscoreMenu.SetActive(false);
        //EventSystem.current.SetSelectedGameObject(menuFirstButton);
        principalMenu.SetActive(true);
    }

    //Obrir Menu Puntuacio
    public void OpenMenuHighScore()
    {
        Debug.Log("MenuHighAbierto");
        highscoreMenu.SetActive(true);
        //GameObject.FindGameObjectWithTag("Highscore").SetActive(true);
        //EventSystem.current.SetSelectedGameObject(controlsFirstButton);
        principalMenu.SetActive(false);
    }

    //Sortir Joc
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game");
    }
}
