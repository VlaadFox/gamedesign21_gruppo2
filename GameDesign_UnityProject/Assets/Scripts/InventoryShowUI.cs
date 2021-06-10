using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryShowUI : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject inventoryMenuUI;
    public GameObject playerController;
    public GameObject canvasMenuPausa;
    public GameObject canvasMiniMap;
    public GameObject emptyTexts;

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
        /*if (GameIsPaused && Input.GetKeyDown(KeyCode.Escape))
            Resume();*/
    }

    //

    public void Resume()
    {
        inventoryMenuUI.SetActive(false);
        emptyTexts.SetActive(false);
        canvasMenuPausa.SetActive(true);
        canvasMiniMap.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //AudioListener.pause = false; utile se mettiamo musica/audio
        Cursor.visible = false;
        playerController.GetComponent<CharacterController>().enabled = true;
    }

    void Pause()
    {
        inventoryMenuUI.SetActive(true);
        canvasMenuPausa.SetActive(false);
        canvasMiniMap.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //AudioListener.pause = true; utile se mettiamo musica/audio
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.GetComponent<CharacterController>().enabled = false;
    }
}
