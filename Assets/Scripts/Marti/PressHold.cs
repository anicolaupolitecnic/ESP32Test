using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressHold : MonoBehaviour
{
    [SerializeField] private Button texteInici;
    [SerializeField] private GameObject menuCanvas;

    private GameMenu gameMenu;

    private GameObject menuInstanciat;
    private bool iniciJoc;

    public Slider slider; // Asignar el slider
    public KeyCode key = KeyCode.Space; // Tecla por defecto: Espacio
    public float speed = 1f; // Velocidad de movimiento
    private bool holderOk;
    


    void Start()
    {

    }

    private void Update()
    {
        if (!holderOk)
        {
            if (Input.GetKey(key)) // Si la tecla est� presionada
            {
                float newValue = slider.value + (speed * Time.deltaTime); // Calcular nuevo valor
                slider.value = Mathf.Clamp(newValue, slider.minValue, slider.maxValue); // Limitar el valor dentro del rango
            }
            else
            {
                float newValue = slider.value - (speed * 2 *  Time.deltaTime);
                slider.value = Mathf.Max(newValue, slider.minValue); // Limitar a valor m�nimo
            }

            if (slider.value == slider.maxValue)
            {
                holderOk = true;
                Comen�arJoc();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TirarRaycast();
        }
    }

    private void Comen�arJoc()
    {
        iniciJoc = true;

        slider.gameObject.SetActive(false);

        texteInici.gameObject.SetActive(false);

        Vector3 enfrente = new Vector3(transform.localPosition.x, transform.localPosition.y + 10, transform.localPosition.z + 2020);

        menuInstanciat = Instantiate(menuCanvas, enfrente, Quaternion.identity);
        gameMenu = menuInstanciat.GetComponent<GameMenu>();
    }

    private void TirarRaycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
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
        else
        {
            Debug.Log("Miss");

        }
    }
}