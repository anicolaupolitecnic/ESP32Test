using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DianaController;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
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
            switch (hit.collider.gameObject.GetComponent<DianaController>().GetPointType())
            {
                case PointsHit.Bad:
                    Debug.Log("10");
                    gameManager.SetNewPuntuation(PointsHit.Bad);
                    break;

                case PointsHit.Good:
                    Debug.Log("25");
                    gameManager.SetNewPuntuation(PointsHit.Good);
                    break;
                
                case PointsHit.VeryGood:
                    Debug.Log("50");
                    gameManager.SetNewPuntuation(PointsHit.VeryGood);
                    break;

                case PointsHit.Perfect:
                    Debug.Log("100");
                    gameManager.SetNewPuntuation(PointsHit.Perfect);
                    break;

                case PointsHit.Gold:
                    Debug.Log("200");
                    gameManager.SetNewPuntuation(PointsHit.Gold);
                    break;
            }
            //Destroy(hit.collider.transform.root.gameObject);
        }
        else
        {
            Debug.Log("Miss");
            gameManager.SetNewPuntuation(PointsHit.Miss);
        }
    }
}
