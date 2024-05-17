using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static DianaController;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private GameplayManager gameManager;
    [SerializeField] private float lastShotTime = 0f;
    [SerializeField] private float delay = 0.175f;
    private GameplayManager gpManager;
    private int contador = 0;

    private void Start()
    {
        contador = 0;
        gpManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
        AudioManager.I.PlaySound(SoundName.Game_music);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastShotTime >= delay)
            {
                TirarRaycast();
                lastShotTime = Time.time;
            }
        }
    }

    private void TirarRaycast()
    {
        AudioManager.I.PlaySound(SoundName.Shot);

        if (gpManager.timerIsRunning)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit))
            {
                switch (hit.collider.gameObject.GetComponent<DianaController>().GetPointType())
                {
                    case PointsHit.Bad:
                        gameManager.SetNewPuntuation(PointsHit.Bad);
                        AudioManager.I.PlaySound(SoundName.Impact);
                        break;

                    case PointsHit.Good:
                        gameManager.SetNewPuntuation(PointsHit.Good);
                        AudioManager.I.PlaySound(SoundName.Impact);
                        break;

                    case PointsHit.VeryGood:
                        gameManager.SetNewPuntuation(PointsHit.VeryGood);
                        AudioManager.I.PlaySound(SoundName.Impact);
                        break;

                    case PointsHit.Perfect:
                        gameManager.SetNewPuntuation(PointsHit.Perfect);
                        AudioManager.I.PlaySound(SoundName.Impact);
                        break;

                    case PointsHit.Gold:
                        gameManager.SetNewPuntuation(PointsHit.Gold);
                        AudioManager.I.PlaySound(SoundName.Impact);
                        break;
                }
                Destroy(hit.collider.transform.root.gameObject);
                hit.collider.transform.root.gameObject.GetComponent<Bullseye>().SpawnAnother();
            }
            else
            {
                gameManager.SetNewPuntuation(PointsHit.Miss);
                AudioManager.I.PlaySound(SoundName.Missed);
            }
        } 
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
            {
                contador++;
                Debug.Log("anar a menu. Contador = " + contador);
                if (contador >= 3)
                {
                    contador = 0;
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().EnableMenuGO();
                }

            }
        }
        
    }
}
