using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{

    private string scene = "_StartMenu";
    private string scene1 = "Video";
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++){
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if(Object.FindObjectsOfType<DontDestroy>()[i].name == gameObject.name)
                {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == scene|| SceneManager.GetActiveScene().name == scene1)
        {
            Debug.Log("restart");
            Destroy(this.gameObject);
        }
    }


}
