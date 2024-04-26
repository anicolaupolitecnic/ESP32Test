using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DianaController;

public class RayCastController : MonoBehaviour
{
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
                    break;

                case PointsHit.Good:
                    Debug.Log("25");
                    break;
                
                case PointsHit.VeryGood:
                    Debug.Log("50");
                    break;

                case PointsHit.Perfect:
                    Debug.Log("100");
                    break;

                case PointsHit.Gold:
                    Debug.Log("200");
                    break;
            }
            //Destroy(hit.collider.transform.root.gameObject);
        }
        else
        {
            Debug.Log("Miss");
        }
    }
}
