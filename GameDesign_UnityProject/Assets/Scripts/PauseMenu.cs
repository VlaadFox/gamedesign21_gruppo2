using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject playerController;
    public GameObject canvasInventoryUI;

    public GameObject pauseFirstButton;

    //public GameObject optionsFirstButton, optionsClosedButton; // servono se canvas "opzioni" è implementato

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pausa"))
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
        pauseMenuUI.SetActive(false);
        canvasInventoryUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //AudioListener.pause = false; utile se mettiamo musica/audio
        Cursor.visible = false;
        //playerController.GetComponent<FirstPersonController>().enabled = true;
        playerController.GetComponent<CharacterController>().enabled = true;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        canvasInventoryUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
        //AudioListener.pause = true; utile se mettiamo musica/audio
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //playerController.GetComponent<FirstPersonController>().enabled = false;
        playerController.GetComponent<CharacterController>().enabled = false;

        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

/*public GameObject pauseMenu;
    public KeyCode pauseKey;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }*/