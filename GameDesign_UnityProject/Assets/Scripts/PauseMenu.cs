using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject playerController;
    public GameObject canvasInventoryUI;
    public GameObject canvas_clicca;

    public GameObject pauseFirstButton;

    public AudioSource soundButtonClick;

    private GameObject mainCamera;


    private void playAudioClick()
    {
        soundButtonClick.Play();
    }

    //public GameObject optionsFirstButton, optionsClosedButton; // servono se canvas "opzioni" è implementato

    void Start()
    {
        pauseMenuUI.SetActive(false);
        canvasPausa.SetActive(true);
        canvasOptions.SetActive(false);
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
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
        playAudioClick();
        mainCamera.GetComponent<AudioSource>().Play();
        pauseMenuUI.SetActive(false);
        canvasInventoryUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //AudioListener.pause = false; utile se mettiamo musica/audio
        Cursor.visible = false;
        //playerController.GetComponent<FirstPersonController>().enabled = true;
        playerController.GetComponent<CharacterController>().enabled = true;
        canvas_clicca.SetActive(false);
    }

    void Pause()
    {
        playAudioClick();
        mainCamera.GetComponent<AudioSource>().Pause();
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


    public GameObject canvasPausa;
    public GameObject canvasOptions;
    public GameObject optionsFirstButton;
    public AudioMixer audioMixer;





    public void fromStartToOptions()
    {
        playAudioClick();
        canvasPausa.SetActive(false);
        canvasOptions.SetActive(true);
        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(optionsFirstButton); 
    }

    public void fromOptionsToStart()
    {
        playAudioClick();
        canvasPausa.SetActive(true);
        canvasOptions.SetActive(false);
        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(pauseFirstButton); 
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volumeMaster", volume);
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}

