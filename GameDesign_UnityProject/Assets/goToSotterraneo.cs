using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToSotterraneo : MonoBehaviour
{
    public GameObject canvas;
    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);


    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

           
            
            FindObjectOfType<LevelLoader>().LoadNextLevelSott();
            

        }
    }

    private void OnTriggerExit(Collider other)
    {
        canvas.SetActive(false);
    }
}
