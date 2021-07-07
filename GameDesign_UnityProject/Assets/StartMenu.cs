using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject pauseFirstButton;

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
}
