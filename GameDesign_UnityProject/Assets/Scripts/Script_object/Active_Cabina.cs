using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Cabina : MonoBehaviour
{
    [SerializeField]
    public GameObject canvas;
    [SerializeField]
    public GameObject BrokenCanvas;


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
            BrokenCanvas.SetActive(false);
        }
    }
}
