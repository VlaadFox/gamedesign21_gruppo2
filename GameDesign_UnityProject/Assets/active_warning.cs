using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class active_warning : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "player")
        {
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "player")
        {
            canvas.SetActive(false);
        }
    }
}
