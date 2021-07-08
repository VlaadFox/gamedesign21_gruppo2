using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance_dog : MonoBehaviour
{
    public string lastExitName;
    public GameObject dog;
   
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("LastExitName") == lastExitName)
        {
            dog.SetActive(true);
            FindObjectOfType<Dialog_trigger>().j = 2;
        }
    }

  
}
