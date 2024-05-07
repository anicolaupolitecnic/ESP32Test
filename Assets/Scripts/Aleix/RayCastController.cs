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
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 || Input.GetMouseButtonDown(0))
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
}
