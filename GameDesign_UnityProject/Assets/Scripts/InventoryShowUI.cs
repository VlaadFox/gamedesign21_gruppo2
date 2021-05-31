using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryShowUI : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject inventoryMenuUI;
    public GameObject playerController;

    void Start()
    {
        inventoryMenuUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
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

    //

    public void Resume()
    {
        inventoryMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //AudioListener.pause = false; utile se mettiamo musica/audio
        Cursor.visible = false;
        playerController.GetComponent<FirstPersonController>().enabled = true;
    }

    void Pause()
    {
        inventoryMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //AudioListener.pause = true; utile se mettiamo musica/audio
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.GetComponent<FirstPersonController>().enabled = false;
    }
}
