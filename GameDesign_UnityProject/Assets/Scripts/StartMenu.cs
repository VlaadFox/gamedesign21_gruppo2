using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour
{
    public GameObject pauseFirstButton;

    public GameObject canvasStart;

    public GameObject canvasOptions;

    public GameObject optionsFirstButton;

    public AudioMixer audioMixer;

    public AudioSource soundButtonClick;


    private void playAudioClick()
    {
        soundButtonClick.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);   

        canvasStart.SetActive(true);
        canvasOptions.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        playAudioClick();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("ScenaPrincipale");
    }

    public void QuitGame()
    {
        playAudioClick();
        Application.Quit();
    }

    public void fromStartToOptions()
    {
        playAudioClick();
        canvasStart.SetActive(false);
        canvasOptions.SetActive(true);
        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(optionsFirstButton); 
    }

    public void fromOptionsToStart()
    {
        playAudioClick();
        canvasStart.SetActive(true);
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
