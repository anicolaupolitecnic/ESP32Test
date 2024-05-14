using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuGO;
    public GameObject jocGO;


    private void Start()
    {
        menuGO.SetActive(true);
    }

    public void EnableJocGO()
    {
        menuGO.SetActive(false);
        jocGO.SetActive(true);
    }

    public void EnableMenuGO()
    {
        menuGO.SetActive(true);
        jocGO.SetActive(false);
    }
}
