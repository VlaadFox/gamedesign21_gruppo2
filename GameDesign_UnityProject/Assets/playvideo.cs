using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playvideo : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {

        SceneManager.LoadScene("Video");
    }
}
