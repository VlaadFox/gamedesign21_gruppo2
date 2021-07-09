using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTurin : MonoBehaviour
{



    /*private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
    }
    */

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            
                if (Input.GetKeyDown(KeyCode.R)|| Input.GetMouseButtonDown(0))
                {
                    FindObjectOfType<LevelLoader>().LoadNextLevelTurin();
                    Debug.Log("gototorino");
                }

            Debug.Log("sononelcollider");

        }
    }

    
}
