using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuRaycastController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI texteInici;
    [SerializeField] private GameMenu menuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TirarRaycast();
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
            Debug.Log("Miss");
   
        }
    }
}
