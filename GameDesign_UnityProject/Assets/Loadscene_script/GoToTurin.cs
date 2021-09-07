using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTurin : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter(Collider collider)
    {
        
        
           canvas.SetActive(true);
        
    }
    private void OnTriggerExit(Collider collider)
    {
        
            canvas.SetActive(false);
       
    }


    /*private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
    }
    */

    private void OnTriggerStay(Collider collider)
    {
       
            
                if (Input.GetKeyDown(KeyCode.R)|| Input.GetButtonDown("Interactions"))
                {
                    FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
                    Debug.Log("gototorino");
                }

            Debug.Log("sononelcollider");

        
    }

    
}
