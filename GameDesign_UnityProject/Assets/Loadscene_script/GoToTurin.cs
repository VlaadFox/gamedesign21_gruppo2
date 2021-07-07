using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTurin : MonoBehaviour
{
    

   
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<LevelLoader>().LoadNextLevel1();
    }

}
