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




    // Start is called before the first frame update
    void Start()
    {
        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("ScenaPrincipale");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void fromStartToOptions()
    {
        canvasStart.SetActive(false);
        canvasOptions.SetActive(true);
        // tolgo preventivamente qualsiasi selezione rimasta su qualche oggetto
        EventSystem.current.SetSelectedGameObject(null);
        // ora posso selezionare in oggetto
        EventSystem.current.SetSelectedGameObject(optionsFirstButton); 
    }

    public void fromOptionsToStart()
    {
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
}
