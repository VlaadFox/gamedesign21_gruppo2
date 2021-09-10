using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Elimina : MonoBehaviour
{
    private static Elimina _instance;

    public static Elimina Instance { get { return _instance; } }
    public string scene = "_StartMenu";
    public GameObject gg;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        gg = GameObject.Find("antagonista");

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name == scene)
        {
            Debug.Log("restart");

            gg.SetActive(true);

            Destroy(gg);
            Destroy(this.gameObject);
        }
    }

}

