using System.Collections;
using StarterAssets;
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
    public AudioSource canzonePausa;
    public AudioSource suoniCitta;
    public AudioSource suoniNatura;

    private GameObject mainCamera;

    public GameObject suonoCane;
    public AudioSource neon;
    public GameObject canvasdialoghi, canvasogetti;

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
        canvasComandi.SetActive(false);
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
                if (!canvasdialoghi.active)
                {
                    if (!canvasogetti.active)
                    {
                        Pause();
                    }
                }
            }
        }
    }

    //

    public void Resume()
    {
        suonoCane.SetActive(true);
        playAudioClick();
        suoniCitta.Play();
        suoniNatura.Play();
        canzonePausa.Stop();
        //mainCamera.GetComponent<AudioSource>().Play();
        pauseMenuUI.SetActive(false);
        canvasInventoryUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
        //AudioListener.pause = false; utile se mettiamo musica/audio
        Cursor.visible = false;
        playerController.GetComponent<ThirdPersonController>().enabled = true;
        playerController.GetComponent<CharacterController>().enabled = true;
        canvas_clicca.SetActive(false);
    }

    void Pause()
    {
        suonoCane.SetActive(false);
        playAudioClick();
        suoniCitta.Stop();
        suoniNatura.Stop();
        canzonePausa.Play();
        //mainCamera.GetComponent<AudioSource>().Pause();
        pauseMenuUI.SetActive(true);
        canvasInventoryUI.SetActive(false);
        //Time.timeScale = 0f;
        GameIsPaused = true;
        //AudioListener.pause = true; utile se mettiamo musica/audio
        //Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.GetComponent<ThirdPersonController>().enabled = false;
        //playerController.GetComponent<CharacterController>().enabled = false;

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
    public GameObject canvasComandi;
    public GameObject backFirstButton;
    public GameObject commandsFirstButton;





    public void fromStartToOptions()
    {
        playAudioClick();
        canvasPausa.SetActive(false);
        canvasOptions.SetActive(true);
        canvasComandi.SetActive(false);
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
        canvasComandi.SetActive(false);
        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(pauseFirstButton); 
    }

    public void fromOptionsToCommands()
    {
        playAudioClick();
        canvasOptions.SetActive(false);
        canvasComandi.SetActive(true);
        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(backFirstButton); // back button
    }

    public void fromCommandsToOptions()
    {
        playAudioClick();
        canvasOptions.SetActive(true);
        canvasComandi.SetActive(false);
        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(commandsFirstButton); 
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

