using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTurin : MonoBehaviour
{







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
