using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missionShow : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject canvasMissioni;
    void Start()
    {
        //inventoryMenuUI.SetActive(false);
        canvasMissioni.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) || Input.GetButtonDown("Inventario"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        //inventoryMenuUI.SetActive(false);
        canvasMissioni.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        //inventoryMenuUI.SetActive(true);
        canvasMissioni.SetActive(true);
        GameIsPaused = true;
    }
}
