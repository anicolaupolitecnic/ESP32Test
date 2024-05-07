using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DianaController;

public class RayCastController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Start()
    {
        AudioManager.I.PlaySound(SoundName.Game_music);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TirarRaycast();
        }

    }

    private void TirarRaycast()
    {
        AudioManager.I.PlaySound(SoundName.Shot);

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            switch (hit.collider.gameObject.GetComponent<DianaController>().GetPointType())
            {
                case PointsHit.Bad:
                    Debug.Log("10");
                    gameManager.SetNewPuntuation(PointsHit.Bad);
                    AudioManager.I.PlaySound(SoundName.Impact);
                    break;

                case PointsHit.Good:
                    Debug.Log("25");
                    gameManager.SetNewPuntuation(PointsHit.Good);
                    AudioManager.I.PlaySound(SoundName.Impact);
                    break;
                
                case PointsHit.VeryGood:
                    Debug.Log("50");
                    gameManager.SetNewPuntuation(PointsHit.VeryGood);
                    AudioManager.I.PlaySound(SoundName.Impact);
                    break;

                case PointsHit.Perfect:
                    Debug.Log("100");
                    gameManager.SetNewPuntuation(PointsHit.Perfect);
                    AudioManager.I.PlaySound(SoundName.Impact);
                    break;

                case PointsHit.Gold:
                    Debug.Log("200");
                    gameManager.SetNewPuntuation(PointsHit.Gold);
                    AudioManager.I.PlaySound(SoundName.Impact);
                    break;
            }
            //Destroy(hit.collider.transform.root.gameObject);
            //hit.collider.transform.root.gameObject.GetComponent<Bullseye>().SpawnAnother();
        }
        else
        {
            Debug.Log("Miss");
            gameManager.SetNewPuntuation(PointsHit.Miss);
            AudioManager.I.PlaySound(SoundName.Missed);
        }
    }
}
