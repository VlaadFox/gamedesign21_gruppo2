using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRoom : MonoBehaviour
{
    public GameObject DOG;
    public GameObject canvas_a;

    private void OnTriggerEnter(Collider other)
    {
        canvas_a.SetActive(true);
        
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            DOG.SetActive(true);
            FindObjectOfType<Energy>().UseEnrgy();
            FindObjectOfType<LevelLoader>().LoadNextLevelRoom();
           // FindObjectOfType<Dialog_trigger>().Getenter();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvas_a.SetActive(false);
    }
    
}

