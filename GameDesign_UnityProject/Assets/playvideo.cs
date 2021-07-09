using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playvideo : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "player")
        {
            FindObjectOfType<LevelLoader>().LoadNextLevelvideo();
        }
    }
}
