using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findgo : MonoBehaviour
{
    public GameObject canvas;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canvas.SetActive(true);


        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canvas.SetActive(false);
           
        }
    }
}
