using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuRaycastController : MonoBehaviour
{
    [SerializeField] private Button texteInici;
    [SerializeField] private GameObject menuCanvas;
    private GameManager gameManager;
    private GameObject menuInstanciat;
    private GameMenu gameMenu;

    [SerializeField] private float lastShotTime = 0f;
    [SerializeField] private float delay = 0.175f;

    private int contador;
    private bool iniciJoc;

    // Start is called before the first frame update
    void Start()
    {
        iniciJoc = true;
        contador = 0;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastShotTime >= delay)
            {
                TirarRaycast();
                lastShotTime = Time.time;
            }

            contador++;

            if (iniciJoc & contador >= 3)
            {
                texteInici.gameObject.SetActive(false);

                Vector3 enfrente = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 10, Camera.main.transform.position.z+ 2020);

                menuInstanciat = Instantiate(menuCanvas, enfrente, Quaternion.identity);
                menuInstanciat.transform.SetParent(gameManager.menuGO.transform);
                gameMenu = menuInstanciat.GetComponent<GameMenu>();

                iniciJoc = false;
            }
        }
    }

    private void TirarRaycast()
    {
        AudioManager.I.PlaySound(SoundName.Shot);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit))
        {
            switch (hit.collider.gameObject.name)
            {
                case "Play":
                    gameMenu.StartGame();
                    break;
                case "HighScore":
                    gameMenu.OpenMenuHighScore();
                    break;
                case "Back":
                    gameMenu.CloseMenuHighScore();
                    break;
            }
        }
    }
}
