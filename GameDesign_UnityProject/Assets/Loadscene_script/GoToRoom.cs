using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRoom : MonoBehaviour
{

    public GameObject canvas_a;
    private void OnTriggerEnter(Collider other)
    {
        canvas_a.SetActive(true);
        
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FindObjectOfType<Energy>().UseEnrgy();
            FindObjectOfType<LevelLoader>().LoadNextLevelRoom();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvas_a.SetActive(false);
    }
}

