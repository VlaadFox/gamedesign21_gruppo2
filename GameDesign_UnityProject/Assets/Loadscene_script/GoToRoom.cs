using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRoom : MonoBehaviour
{
    
   
    private void OnTriggerEnter(Collider other)
    {
        
        FindObjectOfType<LevelLoader>().LoadNextLevelRoom();
    }


}

