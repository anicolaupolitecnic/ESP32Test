using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuRaycastController : MonoBehaviour
{
    [SerializeField] private Button texteInici;
    [SerializeField] private GameMenu menuCanvas;

    private int contador;
    private bool iniciJoc;

    // Start is called before the first frame update
    void Start()
    {
        iniciJoc = true;
        contador = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            TirarRaycast();

            contador++;

            if (iniciJoc & contador == 3)
            {
                texteInici.gameObject.SetActive(false);

                Vector3 enfrente = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z+ 2020);

                Instantiate(menuCanvas, enfrente, Quaternion.identity);

                iniciJoc = false;
            }
        }

    }

    private void TirarRaycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            switch (hit.collider.gameObject.name)
            {
                case "Play":
                    menuCanvas.StartGame();
                    break;
                case "HighScore":
                    menuCanvas.OpenMenuHighScore();
                    break;
                case "Back":
                    menuCanvas.CloseMenuHighScore();
                    break;
            }
        }
        else
        {
            //Debug.Log("Miss");
   
        }
    }
}
