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

    //private AudioSource musicasound;


    [SerializeField] private GameObject principalMenu;
    [SerializeField] private GameObject highscoreMenu;
    //[SerializeField] private GameObject aboutMenu;
    //[SerializeField] private GameObject creatorsMenu;

    //public GameObject menuFirstButton, optionsFirstButton, controlsFirstButton, aboutFirstButton, creatorsFirstButton;


    private void Start()
    {

    }

    //Obrir Scene Joc
    public void StartGame()
    {
        Debug.Log("StartGame");
        //SceneManager.LoadScene("PlayerSelection");
    }

    ////Tancar Menu About
    //public void CloseMenuAbout()
    //{
    //    aboutMenu.SetActive(false);
    //    //EventSystem.current.SetSelectedGameObject(menuFirstButton);
    //    principalMenu.SetActive(true);
    //}

    //Tancar Menu Puntuacio
    public void CloseMenuHighScore()
    {
        highscoreMenu.SetActive(false);
        //EventSystem.current.SetSelectedGameObject(menuFirstButton);
        principalMenu.SetActive(true);
    }

    ////Obrir Menu Options
    //public void OpenMenuOptions()
    //{
    //    optMenu.SetActive(true);
    //    //EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    //    principalMenu.SetActive(false);
    //}

    ////Obrir Menu About
    //public void OpenMenuAbout()
    //{
    //    aboutMenu.SetActive(true);
    //    //EventSystem.current.SetSelectedGameObject(aboutFirstButton);
    //    principalMenu.SetActive(false);
    //}

    //Obrir Menu Puntuacio
    public void OpenMenuHighScore()
    {
        highscoreMenu.SetActive(true);
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
